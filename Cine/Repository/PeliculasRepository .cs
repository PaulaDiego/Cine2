using Cine.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Cine.Repository
{
    public class PeliculasRepository : IPeliculasRepository
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        public Pelicula Create(Pelicula _pelicula)
        {
            return ApplicationDbContext.applicationDbContext.Peliculas.Add(_pelicula);
        }

        public Pelicula Delete(long id)
        {
            Pelicula Pelicula = this.Read(id);
            if(Pelicula == null)
            {
                throw new NoEncontradoException("No se ha encontrado la Pelicula  a eliminar");
            }
            return ApplicationDbContext.applicationDbContext.Peliculas.Remove(Pelicula);

        }

        public void PutPelicula(Pelicula Pelicula)
        {
            ApplicationDbContext.applicationDbContext.Entry(Pelicula).State = EntityState.Modified;
        }

        public Pelicula Read(long id)
        {
            return ApplicationDbContext.applicationDbContext.Peliculas.Find(id);
        }

        public IQueryable<Pelicula> ReadPeliculas()
        {
            IList<Pelicula> lista = new List<Pelicula>(ApplicationDbContext.applicationDbContext.Peliculas);
            return lista.AsQueryable();
        }
    }
}