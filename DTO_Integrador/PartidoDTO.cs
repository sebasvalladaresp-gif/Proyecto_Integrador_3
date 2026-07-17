using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos_Integrador;
namespace DTO_Integrador
{
    public class PartidoDTO
    {
        public string SeleccionLocal { get; set; }
        public string SeleccionVisitante { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string Estadio { get; set; }
        public string Fase { get; set; }
        public string Estado { get; set; }
    }
}
