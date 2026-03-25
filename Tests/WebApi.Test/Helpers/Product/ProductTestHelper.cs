using CommonTestUtilities.Requests.FeedPost;
using CommonTestUtilities.Requests.Product;
using Daylon.RateMeApp.Infrastructure.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using System.Text.Json;

namespace WebApi.Test.Helpers.Product
{
    public class ProductTestHelper
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory _factory;

        public ProductTestHelper(HttpClient client, CustomWebApplicationFactory? factory = default)
        {
            _client = client;
            _factory = factory!;
        }

        // Post
        public async Task CreateProductsAsync(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var request = RequestCreateProductJsonBuilder.Build();
                await _client.PostAsJsonAsync("/api/Product", request);
            }
        }

        public async Task CreatePostAndProductAsync(int count)
        {
            var productId = await CreateProductAndGetIdAsync();

            for (var i = 0; i < count; i++)
            {
                var request = RequestCreateFeedPostJsonBuilder.Build(productId);
                await _client.PostAsJsonAsync("/api/FeedPost", request);
            }
        }

        public async Task<Guid> CreateProductAndGetIdAsync()
        {
            await CreateProductsAsync(1);
            var response = await _client.GetAsync("/api/Product");
            var json = await ReadJsonAsync(response);
            return json[0].GetProperty("id").GetGuid();
        }

        public async Task<Guid> CreatePostAndGetIdAsync()
        {
            await CreatePostAndProductAsync(1);
            var response = await _client.GetAsync("/api/FeedPost");
            var json = await ReadJsonAsync(response);
            return json[0].GetProperty("id").GetGuid();
        }

        // Delete
        public async Task ClearFeedPostsAsync()
        {
            using var scope = _factory.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<RateMeAppDbContext>();

            context.FeedPosts.RemoveRange(context.FeedPosts);

            await context.SaveChangesAsync();
        }

        // Read
        public async Task<JsonElement> ReadJsonAsync(HttpResponseMessage response)
        {
            await using var responseBody = await response.Content.ReadAsStreamAsync();
            var document = await JsonDocument.ParseAsync(responseBody);
            return document.RootElement.Clone();
        }
    }
}