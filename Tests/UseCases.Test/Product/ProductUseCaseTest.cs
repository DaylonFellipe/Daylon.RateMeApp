using CommonTestUtilities.Repositories.Product;
using CommonTestUtilities.Requests.Product;
using Daylon.RateMeApp.Application.UseCases.Product;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using UseCases.Test.Helpers;

// The request properties are tested in Validator.Test - empty fields, invalid requests...

namespace UseCases.Test.Product
{
    public class ProductUseCaseTest
    {
        private UseCaseTestHelper Helper = new();

        [Fact]
        public async Task Success()
        {
            var request = RequestCreateProductJsonBuilder.Build();

            var useCase = Helper.ProductCreateUseCase();

            var result = await useCase.ExecuteCreateProductAsync(request);

            result.Should().NotBeNull();
            result.Name.Should().Be(request.Name);
            result.Description.Should().Be(request.Description);
            result.Price.Should().Be(request.Price);
            result.Rating.Should().Be(request.Rating);
            result.ImageUrl.Should().Be(request.ImageUrl);
            result.Category.Should().Be(request.Category);
            result.SubCategory.Should().Be(request.SubCategory);
            result.SupplierOption.Should().Be(request.SupplierOption);
            result.SupplierPersonalizedName.Should().Be(request.SupplierPersonalizedName);
        }

        [Fact]
        public async Task Success_Update()
        {
            var useCase = Helper.ProductCreateUseCase();

            // Create a product
            var requestProduct = RequestCreateProductJsonBuilder.Build();
            var productResult = await useCase.ExecuteCreateProductAsync(requestProduct);

            // Update the product
            var request = RequestUpdateProductJsonBuilder.Build(productResult.Id);
            var result = await useCase.ExecuteUpdateProductAsync(request);

            result.Should().NotBeNull();
            productResult.Id.Should().Be(result.Id);

            result.Name.Should().Be(request.Name);
            result.Description.Should().Be(request.Description);
            result.Price.Should().Be(request.Price);
            result.Rating.Should().Be(request.Rating);
            result.ImageUrl.Should().Be(request.ImageUrl);
            result.Category.Should().Be(request.Category);
            result.SubCategory.Should().Be(request.SubCategory);
            result.SupplierOption.Should().Be(request.SupplierOption);
            result.SupplierPersonalizedName.Should().Be(request.SupplierPersonalizedName);
        }
    }
}