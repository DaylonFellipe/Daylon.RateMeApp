using Daylon.RateMeApp.Application.Helpers;
using Daylon.RateMeApp.Application.Interfaces.FeedPosts;
using Daylon.RateMeApp.Application.UseCases.FeedPost.Validators;
using Daylon.RateMeApp.Communication.Requests.FeedPost;
using Daylon.RateMeApp.Domain.Interfaces.Repositories;
using Daylon.RateMeApp.Exceptions;
using Daylon.RateMeApp.Exceptions.ExceptionBases;

namespace Daylon.RateMeApp.Application.UseCases.FeedPost
{
    public class FeedPostUseCase(IFeedPostRepository feedRepository, IProductRepository productRepository) : IFeedPostUseCase
    {
        private readonly IFeedPostRepository _feedRepository = feedRepository;
        private readonly IProductRepository _productRepository = productRepository;
        private readonly ApplicationHelper Helper = new();

        // Post
        public async Task<Domain.Entities.FeedPost> CreatePostAsync(RequestCreateFeedPostJson request)
        {
            // Validate
            await Helper.ValidateRequestAsync(request, new CreateFeedPostValidator());

            if (!await _productRepository.ExisteProductAsync(request.ProductId))
                throw new RateMeAppException(string.Format((ResourceMessagesException.PRODUCT_ID_NO_FOUND), request.ProductId));

            var product = await _productRepository.GetProductByIdAsync(request.ProductId);

            // Map
            var feedPost = new Domain.Entities.FeedPost
            {
                Id = Guid.NewGuid(),
                Product = product!,
                IsFavorite = request.IsFavorite
            };

            // Save
            await _feedRepository.CreateFeedPostAsync(feedPost);

            return feedPost;
        }

        // Put
        public async Task<Domain.Entities.FeedPost> UpdatePostAsync(RequestUpdateFeedPostJson request)
        {
            // Get existing post
            var feedPost = await _feedRepository.GetFeedPostByIdAsync(request.Id) ??
                throw new RateMeAppException(string.Format((ResourceMessagesException.POST_ID_NO_FOUND), request.Id));

            // Validate
            await Helper.ValidateRequestAsync(request, new UpdateFeedPostValidator());

            // Update

            if (request.ProductId.HasValue)
            {
                var product = await _productRepository.GetProductByIdAsync(request.ProductId.Value);
                feedPost.Product = product!;
            }

            if (request.IsFavorite.HasValue)
                feedPost.IsFavorite = request.IsFavorite.Value;

            // Save
            await _feedRepository.UpdateFeedPostAsync(feedPost);

            return feedPost;
        }
    }
}