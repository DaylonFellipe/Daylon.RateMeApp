using Daylon.RateMeApp.Communication.Requests.Product;

namespace Daylon.RateMeApp.Application.Interfaces.Products
{
    public interface IProductUseCase
    {
        Task<Domain.Entity.Product> ExecuteCreateProductAsync(RequestCreateProductJson request);
    }
}