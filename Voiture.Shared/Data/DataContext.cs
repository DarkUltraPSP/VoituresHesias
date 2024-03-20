using Microsoft.EntityFrameworkCore;

namespace Voitures.Shared.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Entity.Voiture> Voitures { get; set; }
        public DbSet<Entity.Entretien> Entretiens { get; set; }
    }
}
