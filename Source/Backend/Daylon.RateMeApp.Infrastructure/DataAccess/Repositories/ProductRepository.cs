using Daylon.RateMeApp.Domain.Entity;
using Daylon.RateMeApp.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Daylon.RateMeApp.Infrastructure.DataAccess.Repositories
{
    public class ProductRepository(RateMeAppDbContext dbContext) : IProductRepository
    {
        private readonly RateMeAppDbContext _dbContext = dbContext;

        // Db
        private async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        // Get
        public async Task<IEnumerable<Product>> GetAllProductsAsync() =>
            await _dbContext.Products.ToListAsync();

        public async Task<Product?> GetProductByIdAsync(Guid id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product ?? throw new KeyNotFoundException($"Product with id {id} not found.");
        }

        // Post
        public async Task CreateProductAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await SaveChangesAsync();
        }

        // Delete
        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var product = await GetProductByIdAsync(id);

            if (product == null)
                return false;

            _dbContext.Products.Remove(product);

            await SaveChangesAsync();
            return true;
        }
    }
}