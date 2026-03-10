using Daylon.RateMeApp.Application.DTOs.Product;
using Daylon.RateMeApp.Application.Interfaces.Products;
using Daylon.RateMeApp.Communication.Requests.Product;
using Daylon.RateMeApp.Domain.Entity;
using Daylon.RateMeApp.Domain.Entity.Enum;
using Daylon.RateMeApp.Domain.Interfaces.Repositories;
using Daylon.RateMeApp.Exceptions;

namespace Daylon.RateMeApp.Application.Services.Products
{
    public class ProductService(IProductRepository productRepository, IProductUseCase productUseCase) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IProductUseCase _productUseCase = productUseCase;

        // Get
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();

            return products;
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            return product ?? throw new KeyNotFoundException(string.Format(ResourceMessagesException.PRODUCT_ID_NO_FOUND));
        }

        // Post
        public async Task<ProductDTO> CreateProductAsync(RequestCreateProductJson request)
        {
            var product = await _productUseCase.ExecuteCreateProductAsync(request);

            var productDTO = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = (product.Price ?? 0),
                Rating = product.Rating ?? 0,
                Category = product.Category,
                SubCategory = product.SubCategory,
                SupplierName = GetSupplierName(product)
            };

            return productDTO;
        }

        // Delete
        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var result = await _productRepository.DeleteProductAsync(id);

            return result;
        }

        // Auxiliary Methods
        private static string GetSupplierName(Product product)
        {
            if (product.SupplierOption.HasValue && product.SupplierOption != SupplierOptionsEnum.Indefinite)
                return product.SupplierOption.Value.ToString();

            if (!string.IsNullOrWhiteSpace(product.SupplierPersonalizedName))
                return product.SupplierPersonalizedName;

            return "Unknown Supplier";
        }
    }
}