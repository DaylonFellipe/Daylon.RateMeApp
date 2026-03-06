using Daylon.RateMeApp.Application.Interfaces.Products;
using Daylon.RateMeApp.Domain.Entity;
using Daylon.RateMeApp.Domain.Interfaces.Repositories;

namespace Daylon.RateMeApp.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();

            return products;
        }
    }
}