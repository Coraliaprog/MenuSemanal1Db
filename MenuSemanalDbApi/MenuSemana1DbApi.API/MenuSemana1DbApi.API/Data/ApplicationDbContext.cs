using MenuSemana1DbApi.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MenuSemana1DbApi.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Comida> Comidas { get; set; } = null!;
        public DbSet<Ingrediente> Ingredientes { get; set; } = null!;
    }
}