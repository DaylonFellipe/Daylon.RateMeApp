using Daylon.RateMeApp.Domain.Entity;
using Daylon.RateMeApp.Domain.Interfaces.Repositories;
using Daylon.RateMeApp.Exceptions;
using Daylon.RateMeApp.Exceptions.ExceptionBases;
using Microsoft.EntityFrameworkCore;

namespace Daylon.RateMeApp.Infrastructure.DataAccess.Repositories
{
    public class ProductRepository(RateMeAppDbContext dbContext) : IProductRepository
    {
        private readonly RateMeAppDbContext _dbContext = dbContext;

        // Db
        private async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        // Get
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
           var productsList =  await _dbContext.Products.ToListAsync();

            if (productsList == null || productsList.Count == 0)
                throw new RateMeAppException(ResourceMessagesException.PRODUCT_NO_FOUND);

            return productsList;
        }

        public async Task<Product?> GetProductByIdAsync(Guid id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product ?? throw new RateMeAppException(string.Format(ResourceMessagesException.PRODUCT_ID_NO_FOUND, id));
        }

        public async Task<bool> ExisteProductAsync(Guid id)
        {
            var productExists = await _dbContext.Products.AnyAsync(p => p.Id == id);

            return productExists;
        }

        // Post
        public async Task CreateProductAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await SaveChangesAsync();
        }

        // Put
        public async Task UpdateProductAsync(Product product)
        {
            _dbContext.Products.Update(product);
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