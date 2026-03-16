using Daylon.RateMeApp.Domain.Interfaces.Repositories;

namespace CommonTestUtilities.Repositories.Product
{
    public class ProductRepositoryInMemory : IProductRepository
    {
        private readonly List<Daylon.RateMeApp.Domain.Entity.Product> _products = [];

        // Get
        public Task<IEnumerable<Daylon.RateMeApp.Domain.Entity.Product>> GetAllProductsAsync()
        {
            var products = _products.AsEnumerable();
            return Task.FromResult(products);
        }

        public Task<Daylon.RateMeApp.Domain.Entity.Product?> GetProductByIdAsync(Guid id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }

        // Post
        public Task CreateProductAsync(Daylon.RateMeApp.Domain.Entity.Product product)
        {
            _products.Add(product);
            return Task.CompletedTask;
        }

        // Put
        public Task UpdateProductAsync(Daylon.RateMeApp.Domain.Entity.Product product)
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