using Daylon.RateMeApp.Domain.Entity;

namespace Daylon.RateMeApp.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}