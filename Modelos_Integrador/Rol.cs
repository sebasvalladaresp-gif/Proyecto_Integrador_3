using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos_Integrador
{
    public class Rol
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public List<Usuario>? Usuarios { get; set; }
    }
}
