using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos_Integrador
{
    public class RegistroAuditoria
    {
        public int ID { get; set; }

        public int AdministradorId { get; set; }
        public Administrador? Administrador { get; set; }

        public int AccionAdministrativaId { get; set; }
        public AccionAdministrativa? AccionAdministrativa { get; set; }

        public DateTime FechaHora { get; set; }
        public string Descripcion { get; set; }

    }
}
