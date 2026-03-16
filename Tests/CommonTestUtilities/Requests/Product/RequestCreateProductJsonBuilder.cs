using Bogus;
using Daylon.RateMeApp.Communication.Requests.Product;
using Daylon.RateMeApp.Domain.Entity.Enum;

namespace CommonTestUtilities.Requests.Product
{
    public class RequestCreateProductJsonBuilder
    {
        public static RequestCreateProductJson Build()
        {
            return new Faker<RequestCreateProductJson>()
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.Price, f => f.Random.Double(1, 1000))
                .RuleFor(p => p.Rating, f => f.Random.Double(0, 5))
                .RuleFor(p => p.ImageUrl, f => f.Image.PicsumUrl())
                .RuleFor(p => p.Category, f => f.PickRandom<ProductCategoryEnum>())
                .RuleFor(p => p.SubCategory, f => f.PickRandom<ProductSubCategoryEnum>())
                .RuleFor(p => p.SupplierOption, f => f.PickRandom<SupplierOptionsEnum>())
                .Generate();
        }
    }
}