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

        // Tus DbSets actuales
        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<Sede> Sedes { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Seleccion> selecciones { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<RegistroAuditoria> RegistroAuditorias { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
                 modelBuilder.Entity<Partido>()
                .HasOne(p => p.SeleccionLocal)
                .WithMany(s => s.PartidosComoLocal)    
                .HasForeignKey(p => p.SeleccionLocalID)
                .OnDelete(DeleteBehavior.Restrict);

                 modelBuilder.Entity<Partido>()
                .HasOne(p => p.SeleccionVisitante)
                .WithMany(s => s.PartidosComoVisitante)  
                .HasForeignKey(p => p.SeleccionVisitanteID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}