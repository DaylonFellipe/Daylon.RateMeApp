using Daylon.RateMeApp.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Daylon.RateMeApp.Infrastructure.DataAccess
{
    public class RateMeAppDbContext(DbContextOptions<RateMeAppDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; } = null!;
    }
}