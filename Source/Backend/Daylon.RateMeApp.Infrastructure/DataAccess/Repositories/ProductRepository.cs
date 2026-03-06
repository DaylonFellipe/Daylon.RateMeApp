using Daylon.RateMeApp.Domain.Entity;
using Daylon.RateMeApp.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Daylon.RateMeApp.Infrastructure.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly RateMeAppDbContext _dbContext;

        public ProductRepository(RateMeAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync() =>
            await _dbContext.Products.ToListAsync();
    }
}