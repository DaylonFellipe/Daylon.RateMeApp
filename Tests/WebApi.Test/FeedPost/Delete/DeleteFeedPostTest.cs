using Daylon.RateMeApp.Exceptions;
using FluentAssertions;
using WebApi.Test.Helpers.Product;

namespace WebApi.Test.FeedPost.Delete
{
    public class DeleteFeedPostTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;
        private ProductTestHelper Helper => new(_httpClient);

        public DeleteFeedPostTest(CustomWebApplicationFactory factory)
            => _httpClient = factory.CreateClient();

        [Fact]
        public async Task Success()
        {
            var postId = await Helper.CreatePostAndGetIdAsync();

            var response = await _httpClient.DeleteAsync($"/api/FeedPost/{postId}");

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Error_Delete_Post_No_Found()
        {
            Guid invalidId = Guid.NewGuid();

            var response = await _httpClient.DeleteAsync($"/api/FeedPost/{invalidId}");

            response.StatusCode.Should().NotBe(System.Net.HttpStatusCode.NoContent);

            var responseBody = await response.Content.ReadAsStringAsync();

            responseBody.Should().Contain(string.Format((ResourceMessagesException.POST_ID_NO_FOUND), invalidId));
        }
    }
}