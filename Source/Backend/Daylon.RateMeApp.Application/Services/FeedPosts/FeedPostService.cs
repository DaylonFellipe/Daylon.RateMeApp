using Daylon.RateMeApp.Application.DTOs.FeedPost;
using Daylon.RateMeApp.Application.Interfaces.FeedPosts;
using Daylon.RateMeApp.Communication.Requests.FeedPost;
using Daylon.RateMeApp.Domain.Entities;
using Daylon.RateMeApp.Domain.Interfaces.Repositories;

namespace Daylon.RateMeApp.Application.Services.FeedPosts
{
    public class FeedPostService(IFeedPostRepository postRepository, IFeedPostUseCase useCase) : IFeedPostService
    {
        private readonly IFeedPostRepository _postRepository = postRepository;
        private readonly IFeedPostUseCase _useCase = useCase;

        // Get
        public async Task<IEnumerable<FeedPost>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllPostsAsync();

            return posts;
        }

        public async Task<FeedPostDTO> GetFeedPostByIdAsync(Guid id)
        {
            var post = await _postRepository.GetFeedPostByIdAsync(id);

            var postDTO = FeedPostToDTO(post!);

            return postDTO;
        }

        // Post
        public async Task<FeedPostDTO> CreatePostAsync(RequestCreateFeedPostJson request)
        {
            var post = await _useCase.CreatePostAsync(request);

            var postDTO = FeedPostToDTO(post);

            return postDTO;
        }

        // Put
        public async Task<FeedPostDTO> UpdateFeedPostAsync(RequestUpdateFeedPostJson request)
        {
            var post = await _useCase.UpdatePostAsync(request);

            var postDTO = FeedPostToDTO(post);

            return postDTO;
        }

        // Delete
        public async Task<bool> DeleteFeedPostAsync(Guid postId)
        {
            var result = await _postRepository.DeleteFeedPostAsync(postId);

            return result;
        }

        // Auxiliary Methods
        private static FeedPostDTO FeedPostToDTO(FeedPost post)
        {
            return new FeedPostDTO
            {
                Id = post.Id,
                ProductId = post.Product.Id,
                ProductName = post.Product.Name,
                IsFavorite = post.IsFavorite
            };
        }
    }
}