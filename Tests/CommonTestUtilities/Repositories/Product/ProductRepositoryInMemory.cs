using Daylon.RateMeApp.Domain.Interfaces.Repositories;
using Daylon.RateMeApp.Exceptions;
using Daylon.RateMeApp.Exceptions.ExceptionBases;

namespace CommonTestUtilities.Repositories.Product
{
    public class ProductRepositoryInMemory : IProductRepository
    {
        private readonly List<Daylon.RateMeApp.Domain.Entities.Product> _products = [];

        // Get
        public Task<IEnumerable<Daylon.RateMeApp.Domain.Entities.Product>> GetAllProductsAsync()
        {
            var products = _products.AsEnumerable();
            return Task.FromResult(products);
        }

        public Task<Daylon.RateMeApp.Domain.Entities.Product?> GetProductByIdAsync(Guid id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id)
                ?? throw new RateMeAppException(string.Format((ResourceMessagesException.PRODUCT_ID_NO_FOUND), id));

            return Task.FromResult(product)!;
        }

        public async Task<bool> ExisteProductAsync(Guid id)
        {
            var product = await GetProductByIdAsync(id) ??
                throw new RateMeAppException(string.Format((ResourceMessagesException.PRODUCT_ID_NO_FOUND), id));

            if (product is null)
                return false;

            else
                return true;
        }

        // Post
        public Task CreateProductAsync(Daylon.RateMeApp.Domain.Entities.Product product)
        {
            _products.Add(product);
            return Task.CompletedTask;
        }

        // Put
        public Task UpdateProductAsync(Daylon.RateMeApp.Domain.Entities.Product product)
        {
            var existingProduct = GetProductByIdAsync(product.Id).Result;

            if (existingProduct != null)
            {
                _products.Remove(existingProduct);
                _products.Add(product);
            }

            return Task.CompletedTask;
        }

        // Delete
        public Task<bool> DeleteProductAsync(Guid id)
        {
            _products.RemoveAll(p => p.Id == id);
            return Task.FromResult(true);
        }
    }
}