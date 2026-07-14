using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos_Integrador
{
    public class Partido
    {
        public int ID { get; set; }

        public int SeleccionLocalID { get; set; }
        [ForeignKey("SeleccionLocalID")]
        public Seleccion? SeleccionLocal { get; set; }

        // Relación con Seleccion Visitante
        public int SeleccionVisitanteID { get; set; }
        [ForeignKey("SeleccionVisitanteID")]
        public Seleccion? SeleccionVisitante { get; set; }

        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }

        public int EstadioID { get; set; }
        public Estadio? Estadio { get; set; }

        public int FaseID { get; set; }
        public FaseDeJuego? Fase { get; set; }

        public EstadoPartido Estado { get; set; }

        public int? GolesLocal { get; set; }
        public int? GolesVisitante { get; set; }
    }
}
