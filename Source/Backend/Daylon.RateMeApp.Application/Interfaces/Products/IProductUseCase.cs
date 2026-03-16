using Daylon.RateMeApp.Communication.Requests.Product;

namespace Daylon.RateMeApp.Application.Interfaces.Products
{
    public interface IProductUseCase
    {
        // Post
        Task<Domain.Entity.Product> ExecuteCreateProductAsync(RequestCreateProductJson request);

        // Put
        Task<Domain.Entity.Product> ExecuteUpdateProductAsync(RequestUpdateProductJson request);
    }
}