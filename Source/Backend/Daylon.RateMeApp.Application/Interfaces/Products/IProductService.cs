using Daylon.RateMeApp.Application.DTOs.Product;
using Daylon.RateMeApp.Communication.Requests.Product;
using Daylon.RateMeApp.Domain.Entity;

namespace Daylon.RateMeApp.Application.Interfaces.Products
{
    public interface IProductService
    {
        // Get
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);

        // Post
        Task<ProductDTO> CreateProductAsync(RequestCreateProductJson request);

        // Put
        Task<ProductDTO> UpdateProductAsync(RequestUpdateProductJson request);

        // Delete
        Task<bool> DeleteProductAsync(Guid id);
    }
}