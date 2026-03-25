using Daylon.RateMeApp.Domain.Entities;

namespace Daylon.RateMeApp.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        // Get
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(Guid id);
        Task<bool> ExisteProductAsync(Guid id);

        // Post
        Task CreateProductAsync(Product product);

        // Put
        Task UpdateProductAsync(Product product);

        // Delete
        Task<bool> DeleteProductAsync(Guid id);
    }
}