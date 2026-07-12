using Microsoft.EntityFrameworkCore;
using Modelos_Integrador;

namespace Api_Integrador.Data
{
    public class Api_IntegradorContext : DbContext
    {
        public Api_IntegradorContext(DbContextOptions<Api_IntegradorContext> options)
            : base(options)
        {
        }

        public DbSet<Ciudad> Ciudades { get; set; }
    }
}
