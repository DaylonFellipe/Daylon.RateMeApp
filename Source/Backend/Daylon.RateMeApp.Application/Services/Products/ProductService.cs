using Daylon.RateMeApp.Application.Interfaces.Products;
using Daylon.RateMeApp.Communication.Requests.Product;
using Daylon.RateMeApp.Domain.Entity;
using Daylon.RateMeApp.Domain.Interfaces.Repositories;

namespace Daylon.RateMeApp.Application.Services.Products
{
    public class ProductService(IProductRepository productRepository, IProductUseCase productUseCase) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IProductUseCase _productUseCase = productUseCase;

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();

            return products;
        }

        public async Task<Product> CreateProductAsync(RequestCreateProductJson request)
        {
            var products = await _productUseCase.ExecuteCreateProductAsync(request);

            return products;
        }
    }
}