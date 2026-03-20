using Daylon.RateMeApp.Domain.Interfaces.Repositories;
using Daylon.RateMeApp.Exceptions;
using Daylon.RateMeApp.Exceptions.ExceptionBases;

namespace CommonTestUtilities.Repositories.Product
{
    public class ProductRepositoryInMemory : IProductRepository
    {
        private readonly List<Daylon.RateMeApp.Domain.Entity.Product> _products = [];

        // Get
        public Task<IEnumerable<Daylon.RateMeApp.Domain.Entity.Product>> GetAllProducts()
        {
            var products = _products.AsEnumerable();
            return Task.FromResult(products);
        }

        public Task<Daylon.RateMeApp.Domain.Entity.Product?> GetProductById(Guid id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }

        public async Task<bool> ExisteProductAsync(Guid id)
        {
            var product = await GetProductById(id) ??
                throw new RateMeAppException(string.Format((ResourceMessagesException.PRODUCT_ID_NO_FOUND), id));

            if (product is null)
                return false;

            else
                return true;
        }

        // Post
        public Task CreateProduct(Daylon.RateMeApp.Domain.Entity.Product product)
        {
            _products.Add(product);
            return Task.CompletedTask;
        }

        // Put
        public Task UpdateProduct(Daylon.RateMeApp.Domain.Entity.Product product)
        {
            var existingProduct = GetProductById(product.Id).Result;

            if (existingProduct != null)
            {
                _products.Remove(existingProduct);
                _products.Add(product);
            }

            return Task.CompletedTask;
        }

        // Delete
        public Task<bool> DeleteProduct(Guid id)
        {
            _products.RemoveAll(p => p.Id == id);
            return Task.FromResult(true);
        }
    }
}