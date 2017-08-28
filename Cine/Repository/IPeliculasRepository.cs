using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Repository
{
    public interface IPeliculasRepository
    {
        Pelicula Create(Pelicula _Pelicula);
        Pelicula Delete(long id);
        void PutPelicula(Pelicula Pelicula);
        Pelicula Read(long id);
        IQueryable<Pelicula> ReadPeliculas();
    }
}
