using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Cine;
using Cine.Models;
using System.Web.Http.Cors;
using Cine.Service;

namespace Cine.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EntradasController : ApiController
    {
        private IEntradasService EntradasService;
        public EntradasController(IEntradasService _EntradasService)
        {
            this.EntradasService = _EntradasService;
        }

        // GET: api/Entradas
        public IQueryable<Entrada> GetEntradas()
        {
            return this.EntradasService.ReadEntradas();
        }

        // GET: api/Entradas/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult GetEntrada(long id)
        {
            Entrada Entrada = this.EntradasService.GetEntrada(id);
            if (Entrada == null)
            {
                return NotFound();
            }

            return Ok(Entrada);
        }

        // PUT: api/Entradas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntrada(long id, Entrada Entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Entrada.Id)
            {
                return BadRequest();
            }


            try
            {
                this.EntradasService.PutEntrada(Entrada);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (this.EntradasService.GetEntrada(id) == null)
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

        // POST: api/Entradas
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult PostEntrada(Entrada Entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Entrada = this.EntradasService.Create(Entrada);

            return CreatedAtRoute("DefaultApi", new { id = Entrada.Id }, Entrada);
        }

        // DELETE: api/Entradas/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult DeleteEntrada(long id)
        {
            try
            {
                return Ok(this.EntradasService.Delete(id));
            }
            catch (NoEncontradoException e)
            {
                return NotFound();
            }



        }


    }
}