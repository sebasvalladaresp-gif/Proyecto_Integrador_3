using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos_Integrador
{
    public class Seleccion
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string CodigoFifa { get; set; } 

        public Confederacion Confederacion { get; set; }

        public int GrupoId { get; set; }
        public Grupo? Grupo { get; set; }
        public bool Eliminado { get; set; } = false;
        public List<Partido>? PartidosComoLocal { get; set; }
        public List<Partido>? PartidosComoVisitante { get; set; }
    }
}
