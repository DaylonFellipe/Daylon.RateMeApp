using CommonTestUtilities.Requests.FeedPost;
using FluentAssertions;
using System.Net.Http.Json;
using WebApi.Test.Helpers.Product;

namespace WebApi.Test.FeedPost.Post
{
    public class PostFeedPostTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;
        private ProductTestHelper Helper => new(_httpClient);

        public PostFeedPostTest(CustomWebApplicationFactory factory)
            => _httpClient = factory.CreateClient();

        [Fact]
        public async Task Success()
        {
            Guid productId = await Helper.CreateProductAndGetIdAsync();
            var request = RequestCreateFeedPostJsonBuilder.Build(productId);

            var response = await _httpClient.PostAsJsonAsync("/api/FeedPost", request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            var responseBody = await Helper.ReadJsonAsync(response);

            responseBody.GetProperty("productId").GetString().Should().Be(request.ProductId.ToString());
        }
    }
}