using Daylon.RateMeApp.Domain.Entity;

namespace Daylon.RateMeApp.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        // Get
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product?> GetProductById(Guid id);
        Task<bool> ExisteProductAsync(Guid id);

        // Post
        Task CreateProduct(Product product);

        // Put
        Task UpdateProduct(Product product);

        // Delete
        Task<bool> DeleteProduct(Guid id);
    }
}