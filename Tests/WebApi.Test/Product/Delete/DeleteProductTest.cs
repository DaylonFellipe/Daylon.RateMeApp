using Azure.Core;
using CommonTestUtilities.Requests.Product;
using Daylon.RateMeApp.Exceptions;
using FluentAssertions;
using System.Net.Http.Json;
using System.Security.Policy;
using WebApi.Test.Helpers.Product;

namespace WebApi.Test.Product.Delete
{
    public class DeleteProductTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;
        private ProductTestHelper Helper => new(_httpClient);

        public DeleteProductTest(CustomWebApplicationFactory factory)
            => _httpClient = factory.CreateClient();

        [Fact]
        public async Task Success()
        {
            var productId = await Helper.CreateProductAndGetIdAsync();

            var response = await _httpClient.DeleteAsync($"/api/Product?id={productId}");

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Error_Delete_Product_No_Found()
        {
            var invalidId = Guid.NewGuid();

            var response = await _httpClient.DeleteAsync($"/api/Product?id={invalidId}");

            response.StatusCode.Should().NotBe(System.Net.HttpStatusCode.NoContent);

            var responseBody = await response.Content.ReadAsStringAsync();

            responseBody.Should().Contain(string.Format((ResourceMessagesException.PRODUCT_ID_NO_FOUND), invalidId));
        }
    }
}