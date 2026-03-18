using CommonTestUtilities.Requests.Product;
using System.Net.Http.Json;
using System.Text.Json;

namespace WebApi.Test.Helpers.Product
{
    public class ProductTestHelper
    {
        private readonly HttpClient _client;

        public ProductTestHelper(HttpClient client) => _client = client;

        public async Task CreateProductsAsync(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var request = RequestCreateProductJsonBuilder.Build();
                await _client.PostAsJsonAsync("/api/Product", request);
            }
        }

        public async Task<Guid> CreateProductAndGetIdAsync()
        {
            await CreateProductsAsync(1);
            var response = await _client.GetAsync("/api/Product");
            var json = await ReadJsonAsync(response);
            return json[0].GetProperty("id").GetGuid();
        }

        public async Task<JsonElement> ReadJsonAsync(HttpResponseMessage response)
        {
            await using var responseBody = await response.Content.ReadAsStreamAsync();
            var document = await JsonDocument.ParseAsync(responseBody);
            return document.RootElement.Clone();
        }
    }
}