using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Repository
{
    public interface IEntradasRepository
    {
        Entrada Create(Entrada _entrada);
        Entrada Delete(long id);
        void PutEntrada(Entrada Entrada);
        Entrada Read(long id);
        IQueryable<Entrada> ReadEntradas();
    }
}
