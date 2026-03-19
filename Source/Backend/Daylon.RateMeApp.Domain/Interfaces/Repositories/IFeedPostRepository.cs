using Daylon.RateMeApp.Domain.Entities;

namespace Daylon.RateMeApp.Domain.Interfaces.Repositories
{
    public interface IFeedPostRepository
    {
        // Get
        Task<IEnumerable<FeedPost>> GetAllPostsAsync();
        Task<FeedPost?> GetFeedPostByIdAsync(Guid id);
        Task<bool> ExisteFeedPostAsync(Guid id);

        // Post
        Task CreateFeedPostAsync(FeedPost post);

        // Put
        Task UpdateFeedPostAsync(FeedPost post);

        // Delete
        Task<bool> DeleteFeedPostAsync(Guid postId);
    }
}