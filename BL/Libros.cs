using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libros
    {
        public int IdLibro { get; set; }

        public string Titulo { get; set; }
        public int AnioPublicacion { get; set; }
        public string ISBN { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }

        public bool Correct { get; set; }

        public List<object> Objects { get; set; }
        public List<object> Libross { get; set; }

        public object Object { get; set; }
        public static Libros Add(Libros libros)
        {
            Libros result = new Libros();

            try
            {
                using (DL.LBastidaBusquedaLibrosEntities1 contex = new DL.LBastidaBusquedaLibrosEntities1())
                {
                    var query = contex.AddLibro(libros.Titulo, libros.AnioPublicacion, libros.ISBN, libros.Autor, libros.Editorial);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;

            }


            return result;
        }

        public static Libros DeletexAutor(string autor)
        {
            Libros result = new Libros();

            try
            {
                using (DL.LBastidaBusquedaLibrosEntities1 context = new DL.LBastidaBusquedaLibrosEntities1())
                {
                    var query = context.DeleteLibroAutor(autor);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
            }

            return result;
        }

        public static Libros DeletexEditorial(string editorial)
        {
            Libros result = new Libros();

            try
            {
                using (DL.LBastidaBusquedaLibrosEntities1 context = new DL.LBastidaBusquedaLibrosEntities1())
                {
                    var query = context.DeleteLibroEditorial(editorial);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
            }

            return result;
        }

        public static Libros GetAll(Libros libross)
        {
            Libros result = new Libros();

            try
            {
                using (DL.LBastidaBusquedaLibrosEntities1 context = new DL.LBastidaBusquedaLibrosEntities1())
                {
                    var query = context.GetAll(libross.Titulo, libross.Autor);
                    if (query != null)
                    {
                        result.Objects = new List<object>().ToList();
                        foreach (var obj in query)
                        {
                            Libros libros = new Libros();
                            libros.IdLibro = obj.IdLibro;
                            libros.Titulo = obj.Titulo;
                            libros.Autor = obj.Autor;
                            libros.ISBN = obj.ISBN;
                            libros.AnioPublicacion = obj.AnioPublicacion;
                            libros.Editorial = obj.Editorial;
                            result.Objects.Add(libros);

                        }
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
            }

            return result;
        }

        public static Libros GetById(int IdLibro)
        {
            Libros result = new Libros();

            try
            {
                using (DL.LBastidaBusquedaLibrosEntities1 context = new DL.LBastidaBusquedaLibrosEntities1())
                {
                    var obj = context.GetById(IdLibro).SingleOrDefault();
                    if (obj != null)
                    {
                        Libros libros = new Libros();
                        libros.IdLibro = obj.IdLibro;
                        libros.Titulo = obj.Titulo;
                        libros.Autor = obj.Autor;
                        libros.ISBN = obj.ISBN;
                        libros.AnioPublicacion = obj.AnioPublicacion;
                        libros.Editorial = obj.Editorial;
                        result.Object = libros;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
            }

            return result;
        }
    }
}
