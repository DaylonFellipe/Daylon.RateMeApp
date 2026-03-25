using Daylon.RateMeApp.Communication.Requests.Product;

namespace Daylon.RateMeApp.Application.Interfaces.Products
{
    public interface IProductUseCase
    {
        // Post
        Task<Domain.Entities.Product> ExecuteCreateProductAsync(RequestCreateProductJson request);

        // Put
        Task<Domain.Entities.Product> ExecuteUpdateProductAsync(RequestUpdateProductJson request);
    }
}