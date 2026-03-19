using Daylon.RateMeApp.Domain.Entities;

namespace Daylon.RateMeApp.Domain.Interfaces.Repositories
{
    public interface IFeedPostRepository
    {
        // Get
        Task<IEnumerable<FeedPost>> GetAllPostsAsync();
        Task<FeedPost?> GetFeedPostByIdAsync(Guid id);

        // Post
        Task CreateFeedPostAsync(FeedPost post);

        // Delete
        Task<bool> DeleteFeedPostAsync(Guid postId);
    }
}