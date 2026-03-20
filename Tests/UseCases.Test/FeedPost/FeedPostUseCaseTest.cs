using CommonTestUtilities.Requests.FeedPost;
using CommonTestUtilities.Requests.Product;
using FluentAssertions;
using UseCases.Test.Helpers;

namespace UseCases.Test.FeedPost
{
    public class FeedPostUseCaseTest
    {
        private UseCaseTestHelper Helper = new();

        [Fact]
        public async Task Success()
        {
            // Create Product
            var productRequest = RequestCreateProductJsonBuilder.Build();
            var productUseCase = Helper.ProductCreateUseCase();

            var productResult = await productUseCase.ExecuteCreateProductAsync(productRequest);

            // Create Post
            var postRequest = RequestCreateFeedPostJsonBuilder.Build(productResult.Id);
            var postUseCase = Helper.FeedPostCreateUseCase();

            var postResult = await postUseCase.ExecuteCreatePostAsync(postRequest);

            postResult.Should().NotBeNull();
            postResult.Product.Should().Be(productResult);
            postResult.IsFavorite.Should().Be(postRequest.IsFavorite);
        }
    }
}