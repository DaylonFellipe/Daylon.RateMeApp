using Daylon.RateMeApp.Exceptions;
using FluentAssertions;
using System.Net;
using WebApi.Test.Helpers.Product;

namespace WebApi.Test.Product.Get
{
    public class GetProdutctTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;
        private ProductTestHelper Helper => new(_httpClient);

        public GetProdutctTest(CustomWebApplicationFactory factory)
            => _httpClient = factory.CreateClient();

        [Fact]
        public async Task Success_Get_Products()
        {
            await Helper.CreateProductsAsync(3);

            var response = await _httpClient.GetAsync("/api/Product");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseData = await Helper.ReadJsonAsync(response);

            responseData.GetArrayLength().Should().BeGreaterThanOrEqualTo(3);
        }

        [Fact]
        public async Task Error_Get_Products_No_Found()
        {
            await Helper.CreateProductsAsync(0);

            var response = await _httpClient.GetAsync("/api/Product");

            response.StatusCode.Should().NotBe(HttpStatusCode.OK);

            var responseBody = await response.Content.ReadAsStringAsync();

            responseBody.Should().Contain(string.Format(ResourceMessagesException.PRODUCT_NO_FOUND ));
        }

        [Fact]
        public async Task Success_Get_Product_By_Id()
        {
            var productId = await Helper.CreateProductAndGetIdAsync();

            var response = await _httpClient.GetAsync($"/api/Product/{productId}");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseData = await Helper.ReadJsonAsync(response);

            responseData.GetProperty("id").GetGuid().Should().Be(productId);
        }

        [Fact]
        public async Task Error_Get_Product_By_Id_No_Found()
        {
            var invalidId = Guid.NewGuid();

            var response = await _httpClient.GetAsync($"/api/Product/{invalidId}");

            response.StatusCode.Should().NotBe(HttpStatusCode.OK);

            var responseBody = await response.Content.ReadAsStringAsync();

            responseBody.Should().Contain(string.Format((ResourceMessagesException.PRODUCT_ID_NO_FOUND), invalidId));
        }
    }
}