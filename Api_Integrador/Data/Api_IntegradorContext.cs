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
        // DbSet for Confederacion model
        public DbSet<Modelos_Integrador.Confederacion> Confederaciones { get; set; }
        
    }
}
