using Daylon.RateMeApp.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Daylon.RateMeApp.Infrastructure.DataAccess
{
    public class RateMeAppDbContext : DbContext
    {
        public RateMeAppDbContext(DbContextOptions<RateMeAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
    }
}