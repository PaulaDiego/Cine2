using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cine
{
    public class Pelicula
    {
        public long Id { get; set; }
        public String Titulo { get; set; }
        public String Director { get; set; }
        public int Anno { get; set; }
        public String Duracion { get; set; }
    }
}