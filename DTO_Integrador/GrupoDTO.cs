using Modelos_Integrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Integrador
{
    public class GrupoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SeleccionEstadisticaDTO> Selecciones { get; set; } = new List<SeleccionEstadisticaDTO>();
    }
}
