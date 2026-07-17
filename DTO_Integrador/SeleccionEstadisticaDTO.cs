using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//por el momento en deshuso
namespace DTO_Integrador
{
    public class SeleccionEstadisticaDTO
    {
        public string nombre { get; set; }
        public int idGrupo { get; set; }
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
