using Daylon.RateMeApp.Domain.Entities;

namespace Daylon.RateMeApp.Domain.Interfaces.Repositories
{
    public interface IFeedPostRepository
    {
        // Get
        Task<IEnumerable<FeedPost>> GetAllPostsAsync();
    }
}