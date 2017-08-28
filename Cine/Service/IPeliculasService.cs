using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Service
{
    public interface IPeliculasService
    {
        Pelicula Create(Pelicula Pelicula);
        Pelicula Delete(long id);
        Pelicula GetPelicula(long id);
        void PutPelicula(Pelicula Pelicula);
        IQueryable<Pelicula> ReadPeliculas();
    }
}
