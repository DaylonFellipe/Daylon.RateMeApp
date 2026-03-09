using Daylon.RateMeApp.Communication.Requests.Product;
using Daylon.RateMeApp.Domain.Entity;

namespace Daylon.RateMeApp.Application.Interfaces.Products
{
    public interface IProductService
    {
        // Get
        Task<IEnumerable<Product>> GetAllProductsAsync();

        // Post
        Task<Product> CreateProductAsync(RequestCreateProductJson request);
    }
}