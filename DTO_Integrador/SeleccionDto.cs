using Modelos_Integrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Integrador
{
    public class SeleccionDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CodigoFifa { get; set; }
        public string Confederacion { get; set; }
        public string Grupo { get; set; }
        public bool estado { get; set; } = true;
    }
}
