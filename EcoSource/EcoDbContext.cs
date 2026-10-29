using Microsoft.EntityFrameworkCore;

namespace EcoSource
{
    public class EcoDbContext : DbContext
    {
        public EcoDbContext(DbContextOptions<EcoDbContext> options) : base(options)
        {
        }
        public DbSet<Model.Product> Products { get; set; } = null!;

        public DbSet<Model.Category> Categories { get; set; } = null!;
    }
}
