using CameraDeputados.Models;
using Microsoft.EntityFrameworkCore;

namespace CameraDeputados.Infra
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Deputado> Deputados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Deputado>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Despesa>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Despesa>()
                .HasOne(d => d.Deputado)
                .WithMany(dp => dp.Despesas)
                .HasForeignKey(d => d.DeputadoId);
        }
    }
}
