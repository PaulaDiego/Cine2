using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cine
{
    public class Entrada
    {
        public long Id { get; set; }
        public string Sala { get; set; }
        public string Butaca { get; set; }
        public int Fila { get; set; }
        public double Precio { get; set; }
        public String Dia { get; set; }
        public String Hora { get; set; }
        public String Pelicula { get; set; }
    }
}