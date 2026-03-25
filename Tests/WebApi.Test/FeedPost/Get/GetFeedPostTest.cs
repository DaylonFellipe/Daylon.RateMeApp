using Daylon.RateMeApp.Exceptions;
using FluentAssertions;
using System.Net;
using WebApi.Test.Helpers.Product;

namespace WebApi.Test.FeedPost.Get
{
    public class GetFeedPostTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;
        private readonly CustomWebApplicationFactory _factory;
        private ProductTestHelper Helper => new(_httpClient, _factory);

        public GetFeedPostTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Success_Get_Products()
        {
            await Helper.CreatePostAndProductAsync(3);

            var response = await _httpClient.GetAsync("/api/FeedPost");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseData = await Helper.ReadJsonAsync(response);

            responseData.GetArrayLength().Should().BeGreaterThanOrEqualTo(3);
        }

        [Fact]
        public async Task Error_Get_Post_No_Found()
        {
            await Helper.ClearFeedPostsAsync();

            var response = await _httpClient.GetAsync("/api/FeedPost");

            response.StatusCode.Should().NotBe(HttpStatusCode.OK);

            var responseBody = await response.Content.ReadAsStringAsync();

            responseBody.Should().Contain(string.Format(ResourceMessagesException.POST_NO_FOUND));
        }

        [Fact]
        public async Task Success_Get_Post_By_Id()
        {
            var postId = await Helper.CreatePostAndGetIdAsync();

            var response = await _httpClient.GetAsync($"/api/FeedPost/{postId}");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseData = await Helper.ReadJsonAsync(response);

            responseData.GetProperty("id").GetGuid().Should().Be(postId);
        }

        [Fact]
        public async Task Error_Get_Post_By_Id()
        {
            var invalidId = Guid.NewGuid();

            var response = await _httpClient.GetAsync($"/api/FeedPost/{invalidId}");

            response.StatusCode.Should().NotBe(HttpStatusCode.OK);

            var responseBody = await response.Content.ReadAsStringAsync();

            responseBody.Should().Contain(string.Format((ResourceMessagesException.POST_ID_NO_FOUND), invalidId));
        }
    }
}