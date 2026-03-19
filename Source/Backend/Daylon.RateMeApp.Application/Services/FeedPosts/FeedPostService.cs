using Daylon.RateMeApp.Application.Interfaces.FeedPosts;
using Daylon.RateMeApp.Domain.Entities;
using Daylon.RateMeApp.Domain.Interfaces.Repositories;

namespace Daylon.RateMeApp.Application.Services.FeedPosts
{
    public class FeedPostService(IFeedPostRepository postRepository) : IFeedPostService
    {
        private readonly IFeedPostRepository _postRepository = postRepository;

        // Get
        public async Task<IEnumerable<FeedPost>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllPostsAsync();

            return posts;
        }
    }
}