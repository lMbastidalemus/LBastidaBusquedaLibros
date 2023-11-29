using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using BL;
namespace LBastidaBusquedaLibros.Controllers
{
    public class LibrosController : Controller
    {
   
        public ActionResult GetAll()
        {
            Libros libross = new Libros();
            libross.Titulo = "";
            libross.Autor = "";
            using (var client = new HttpClient())
            {
                libross.Libross = new List<object>();
                client.BaseAddress = new Uri("http://localhost:55644/api/libros/");
                var task = client.GetAsync("GetAll" + libross);
                task.Wait();

                var taskResult = task.Result;
                if (taskResult.IsSuccessStatusCode)
                {
                    var readTask = taskResult.Content.ReadAsAsync<Libros>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        Libros resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<Libros>(resultItem.ToString());
                        libross.Libross.Add(resultItemList);
                    }
                }
            }

            Libros result = BL.Libros.GetAll(libross);
            libross.Libross = result.Objects;
          
            return View(libross);
        }

        [HttpPost]
        public ActionResult GetAll(BL.Libros libross)
        {
          
            if (libross.Titulo == null)
            {
                libross.Titulo = "";
            }
            if (libross.Autor == null)
            {
                libross.Autor = "";
            }


            using (var client = new HttpClient())
            {
                libross.Libross = new List<object>();
                client.BaseAddress = new Uri("http://localhost:55644/api/libros/");
                var task = client.GetAsync("GetAll/" + libross);
                task.Wait();

                var taskResult = task.Result;
                if (taskResult.IsSuccessStatusCode)
                {
                    var readTask = taskResult.Content.ReadAsAsync<Libros>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        Libros resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<Libros>(resultItem.ToString());
                        libross.Libross.Add(resultItemList);
                    }
                }
            }


            Libros result = BL.Libros.GetAll(libross);
            libross.Libross = result.Objects;

            return View(libross);
        }
        public ActionResult Form(int? IdLibro)
        {
            Libros result = new Libros();
           
            if(IdLibro != 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:55644/api/libros/");
                    var task = client.GetAsync("GetById/" + IdLibro);
                    task.Wait();

                    var Result = task.Result;

                    if (Result.IsSuccessStatusCode)
                    {
                        var readTaks = Result.Content.ReadAsAsync<Libros>();
                        readTaks.Wait();
                        Libros list = new Libros();
                        list = Newtonsoft.Json.JsonConvert.DeserializeObject<Libros>(readTaks.Result.Object.ToString());
                        result.Object   = list;
                        result.Correct = true;
                    }
                    else
                    {

                    }
                }
            }
            return View(result.Object);
        }

        [HttpPost]
        public ActionResult Form(Libros libros)
        {
            if(libros.IdLibro == 0)
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:55644/api/libros/");
                    var task = client.PostAsJsonAsync<Libros>("", libros);
                    task.Wait();

                    var taskResult = task.Result;
                    if (taskResult.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Agregado correctamente";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error";
                    }
                }
               
            }
            return PartialView("Modal");
        }


        public ActionResult DeletexAutor(string Autor)
        {
            using(var client  = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55644/api/libros/");
                var task = client.DeleteAsync("Delete/Autor/" + Autor);
                task.Wait();

                var taskResult = task.Result;
                if (task.IsCompleted)
                {
                    ViewBag.Mensaje = "Libros eliminados por autor";
                }
                else
                {
                    ViewBag.Mensaje = "Error";
                }
            }
            return PartialView("Modal");

        }

        public ActionResult DeletexEditorial(string Editorial)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55644/api/libros/");
                var task = client.DeleteAsync("Delete/Editorial/" + Editorial);
                task.Wait();

                var taskResult = task.Result;
                if (taskResult.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "Libros eliminados por editorial";
                }
                else
                {
                    ViewBag.Mensaje = "Error";

                }

                return PartialView("Modal");
            }
        }
    }
}