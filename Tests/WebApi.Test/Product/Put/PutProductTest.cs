using CommonTestUtilities.Requests.Product;
using FluentAssertions;
using System.Net.Http.Json;
using WebApi.Test.Helpers.Product;

namespace WebApi.Test.Product.Put
{
    public class PutProductTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;
        private ProductTestHelper Helper => new(_httpClient);

        public PutProductTest(CustomWebApplicationFactory factory)
            => _httpClient = factory.CreateClient();

        [Fact]
        public async Task Success()
        {
           var productId =  await Helper.CreateProductAndGetIdAsync();

            var request = RequestUpdateProductJsonBuilder.Build(productId);

            var response = await _httpClient.PutAsJsonAsync("/api/product", request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var responseBody = await Helper.ReadJsonAsync(response);

            responseBody.GetProperty("id").GetGuid().Should().Be(productId);
            responseBody.GetProperty("name").GetString().Should().Be(request.Name);
        }
    }
}