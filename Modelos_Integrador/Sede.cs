using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos_Integrador
{
    public class Sede
    {
        public int ID { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }

        public List<Estadio>? Estadios { get; set; }
    }
}
