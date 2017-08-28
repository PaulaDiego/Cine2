using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Service
{
    public interface IEntradasService
    {
        Entrada Create(Entrada Entrada);
        Entrada Delete(long id);
        Entrada GetEntrada(long id);
        void PutEntrada(Entrada Entrada);
        IQueryable<Entrada> ReadEntradas();
    }
}
