using Daylon.RateMeApp.Domain.Entities;

namespace Daylon.RateMeApp.Application.Interfaces.FeedPosts
{
    public interface IFeedPostService
    {
        // Get
        Task<IEnumerable<FeedPost>> GetAllPostsAsync();
    }
}
