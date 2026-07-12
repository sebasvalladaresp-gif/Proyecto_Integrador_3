using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos_Integrador
{
    public class Estadio
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public int SedeID { get; set; }
        public Sede? Sede { get; set; }

        public List<Partido>? Partidos { get; set; }
    }
}
