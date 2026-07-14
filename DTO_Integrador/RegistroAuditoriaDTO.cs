using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Integrador
{
    public class RegistroAuditoriaDTO
    {
        public int ID { get; set; }
        public string UsuarioAdmin { get; set; }
        public DateTime FechaHora { get; set; }
        public string Descripcion { get; set; }
    }
}
