using AccessOne.Domain.Entities;
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
                optionsBuilder.UseSqlServer("connectionstring");
            }
        }
    }
}
