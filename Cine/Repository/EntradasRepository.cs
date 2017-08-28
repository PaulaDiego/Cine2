using Cine.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Cine.Repository
{
    public class EntradasRepository : IEntradasRepository
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        public Entrada Create(Entrada _entrada)
        {
            return ApplicationDbContext.applicationDbContext.Entradas.Add(_entrada);
        }

        public Entrada Delete(long id)
        {
            Entrada Entrada = this.Read(id);
            if(Entrada == null)
            {
                throw new NoEncontradoException("No se ha encontrado la Entrada  a eliminar");
            }
            return ApplicationDbContext.applicationDbContext.Entradas.Remove(Entrada);

        }

        public void PutEntrada(Entrada Entrada)
        {
            ApplicationDbContext.applicationDbContext.Entry(Entrada).State = EntityState.Modified;
        }

        public Entrada Read(long id)
        {
            return ApplicationDbContext.applicationDbContext.Entradas.Find(id);
        }

        public IQueryable<Entrada> ReadEntradas()
        {
            IList<Entrada> lista = new List<Entrada>(ApplicationDbContext.applicationDbContext.Entradas);
            return lista.AsQueryable();
        }
    }
}