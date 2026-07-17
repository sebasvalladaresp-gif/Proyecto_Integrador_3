using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos_Integrador
{
    public class AccionAdministrativa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<RegistroAuditoria>? RegistrosAuditoria { get; set; }
    }
}
