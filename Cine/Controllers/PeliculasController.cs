using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Cine.Models;
using System.Web.Http.Cors;
using Cine.Service;

namespace Cine.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PeliculasController : ApiController
    {
        private IPeliculasService PeliculasService;
        public PeliculasController(IPeliculasService _PeliculasService)
        {
            this.PeliculasService = _PeliculasService;
        }

        // GET: api/Peliculas
        public IQueryable<Pelicula> GetPeliculas()
        {
            return this.PeliculasService.ReadPeliculas();
        }

        // GET: api/Peliculas/5
        [ResponseType(typeof(Pelicula))]
        public IHttpActionResult GetPelicula(long id)
        {
            Pelicula Pelicula = this.PeliculasService.GetPelicula(id);
            if (Pelicula == null)
            {
                return NotFound();
            }

            return Ok(Pelicula);
        }

        // PUT: api/Peliculas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPelicula(long id, Pelicula Pelicula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Pelicula.Id)
            {
                return BadRequest();
            }


            try
            {
                this.PeliculasService.PutPelicula(Pelicula);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (this.PeliculasService.GetPelicula(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Peliculas
        [ResponseType(typeof(Pelicula))]
        public IHttpActionResult PostPelicula(Pelicula Pelicula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Pelicula = this.PeliculasService.Create(Pelicula);

            return CreatedAtRoute("DefaultApi", new { id = Pelicula.Id }, Pelicula);
        }

        // DELETE: api/Peliculas/5
        [ResponseType(typeof(Pelicula))]
        public IHttpActionResult DeletePelicula(long id)
        {
            try
            {
                return Ok(this.PeliculasService.Delete(id));
            }
            catch (NoEncontradoException e)
            {
                return NotFound();
            }



        }
    }
}