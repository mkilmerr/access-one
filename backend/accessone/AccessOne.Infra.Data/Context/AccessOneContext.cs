using AccessOne.Domain.Entities;
using AccessOne.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AccessOne.Infra.Data.Context
{
    public class AccessOneContext : DbContext
    {
        public DbSet<Computador> Computadores { get; set; }
        public DbSet<Comando> Comandos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=accessone;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Computador>(new ComputadorMap().Configure);
            modelBuilder.Entity<Comando>(new ComandoMap().Configure);
            modelBuilder.Entity<Grupo>(new GrupoMap().Configure);
        }
    }
}
