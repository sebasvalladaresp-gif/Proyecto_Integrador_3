using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Integrador
{
    public class SeleccionEstadisticaDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int partidosJugados { get; set; }
        public int puntos { get; set; }
        public int golesAFavor { get; set; }
        public int golesEnContra { get; set; }
        public int diferenciaGoles { get; set; }
        public int partidosGanados { get; set; }
        public int partidosEmpatados { get; set; }
        public int partidosPerdidos { get; set; }
        


    }
}
