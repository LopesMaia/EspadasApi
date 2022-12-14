using EspadasApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EspadasApi.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Espada> Espadas { get; set; } //Entidade Espada mapeada para uma tabela Espadas
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Espada>().HasData(
                new Espada
                {
                    Id = 1,
                    Nome = "Cimitarra",
                    Familia = "Flame",
                    Forca = 71,
                    Durabilidade = 100
                },
                new Espada
                {
                    Id = 2,
                    Nome = "Alfange",
                    Familia = "Dark",
                    Forca = 41,
                    Durabilidade = 80
                },
                new Espada
                {
                    Id = 3,
                    Nome = "Montante",
                    Familia = "Dark",
                    Forca = 65,
                    Durabilidade = 94
                }
            );
        }
    }
}
