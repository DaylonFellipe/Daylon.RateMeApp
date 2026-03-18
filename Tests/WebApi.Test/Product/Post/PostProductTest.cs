using CommonTestUtilities.Requests.Product;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Text.Json;
using WebApi.Test.Helpers.Product;

namespace WebApi.Test.Product.Post
{
    public class PostProductTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;
        private ProductTestHelper Helper => new(_httpClient);

        public PostProductTest(CustomWebApplicationFactory factory)
            => _httpClient = factory.CreateClient();

        [Fact]
        public async Task Success()
        {
            var request = RequestCreateProductJsonBuilder.Build();

            var response = await _httpClient.PostAsJsonAsync("/api/product", request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            var responseBody = await Helper.ReadJsonAsync(response);

            responseBody.GetProperty("name").GetString().Should().Be(request.Name);
        }
    }
}