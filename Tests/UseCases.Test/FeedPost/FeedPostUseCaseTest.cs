using CommonTestUtilities.Requests.FeedPost;
using CommonTestUtilities.Requests.Product;
using Daylon.RateMeApp.Application.UseCases.FeedPost;
using Daylon.RateMeApp.Communication.Requests.FeedPost;
using Daylon.RateMeApp.Exceptions;
using Daylon.RateMeApp.Exceptions.ExceptionBases;
using FluentAssertions;
using UseCases.Test.Helpers;

namespace UseCases.Test.FeedPost
{
    public class FeedPostUseCaseTest
    {
        private UseCaseTestHelper Helper = new();

        [Fact]
        public async Task Success_Create()
        {
            var (productResult, postResult, _, postRequest) = await CreateProductAndFeedPostAsync();

            postResult.Should().NotBeNull();
            postResult.Product.Should().Be(productResult);
            postResult.IsFavorite.Should().Be(postRequest.IsFavorite);
        }

        [Fact]
        public async Task Error_Create_Product_Id_No_Found()
        {
            var request = RequestCreateFeedPostJsonBuilder.Build();
            var useCase = Helper.FeedPostCreateUseCase();

            RateMeAppException? exception = null;

            try
            { await useCase.ExecuteCreatePostAsync(request); }

            catch (RateMeAppException ex)
            { exception = ex; }

            exception.Should().NotBeNull();
            exception!.Message.Should().Be(string.Format(ResourceMessagesException.PRODUCT_ID_NO_FOUND, request.ProductId));
        }

        [Fact]
        public async Task Success_Update()
        {
            var (_, postResult, useCase, _) = await CreateProductAndFeedPostAsync();

            // Update Post
            var postUpdateRequest = RequestUpdateFeedPostJsonBuilder.Build(postResult.Id);
            var postUpdatedResult = await useCase.UpdatePostAsync(postUpdateRequest);

            postUpdatedResult.Should().NotBeNull();
            postUpdatedResult.Id.Should().Be(postResult.Id);
            postUpdatedResult.Product.Should().Be(postResult.Product);
            postUpdatedResult.IsFavorite.Should().Be(postResult.IsFavorite);
        }

        [Fact]
        public async Task Error_Update_Post_Id_No_Found()
        {
            var (_, _, useCase, _) = await CreateProductAndFeedPostAsync();

            // Update Post
            var invalidPostId = Guid.NewGuid();

            var postUpdateRequest = RequestUpdateFeedPostJsonBuilder.Build(invalidPostId);

            RateMeAppException? exception = null;

            try
            { await useCase.UpdatePostAsync(postUpdateRequest); }

            catch (RateMeAppException ex)
            { exception = ex; }


            exception.Should().NotBeNull();
            exception.Message.Should().Be(string.Format((ResourceMessagesException.POST_ID_NO_FOUND), invalidPostId));
        }

        [Fact]
        public async Task Error_Update_Product_Id_No_Found()
        {
            var(_, postResult, useCase, _) = await CreateProductAndFeedPostAsync();

            // Update Post
            var invalidProductId = Guid.NewGuid();

            var postUpdateRequest = RequestUpdateFeedPostJsonBuilder.Build(postResult.Id, invalidProductId, false);

            RateMeAppException? exception = null;

            try
            { var teste = await useCase.UpdatePostAsync(postUpdateRequest); }

            catch (RateMeAppException ex)
            { exception = ex; }

            exception.Should().NotBeNull();
            exception.Message.Should().Be(string.Format((ResourceMessagesException.PRODUCT_ID_NO_FOUND), invalidProductId));
        }

        // Auxiliary Methods
        private async Task<(
            Daylon.RateMeApp.Domain.Entities.Product product,
            Daylon.RateMeApp.Domain.Entities.FeedPost post,
            FeedPostUseCase useCase,
            RequestCreateFeedPostJson requestPost
            )> CreateProductAndFeedPostAsync()
        {
            // Create Product
            var productRequest = RequestCreateProductJsonBuilder.Build();
            var productUseCase = Helper.ProductCreateUseCase();

            var productResult = await productUseCase.ExecuteCreateProductAsync(productRequest);

            // Create Post
            var postRequest = RequestCreateFeedPostJsonBuilder.Build(productResult.Id);
            var postUseCase = Helper.FeedPostCreateUseCase();

            var postCreated = await postUseCase.ExecuteCreatePostAsync(postRequest);

            return (productResult, postCreated!, postUseCase, postRequest);
        }
    }
}