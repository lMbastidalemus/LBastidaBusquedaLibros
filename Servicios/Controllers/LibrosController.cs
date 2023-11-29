using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;

namespace Servicios.Controllers
{
    [RoutePrefix("api/libros")]
    public class LibrosController : ApiController
    {
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll(Libros libross)
        {
           
            Libros result = BL.Libros.GetAll(libross);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }


        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(Libros libros)
        {
            Libros result = BL.Libros.Add(libros);
            if (result.Correct)
            {
           
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
               
                return Content(HttpStatusCode.BadRequest, result);
            }
           
        }

        [Route("Delete/Autor/{Autor}")]
        [HttpDelete]
        public IHttpActionResult DeletexAutor(string Autor)
        {
            Libros result = BL.Libros.DeletexAutor(Autor);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest,result);
            }
        }

        [Route("Delete/Editorial/{Editorial}")]
        [HttpDelete]
        public IHttpActionResult DeletexEditorial(string Editorial)
        {
            Libros result = BL.Libros.DeletexEditorial(Editorial);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("GetById/{IdLibro}")]
        [HttpGet]
        public IHttpActionResult GetById(int IdLibro)
        {
            Libros result = BL.Libros.GetById(IdLibro);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

    }
}
