using Daylon.RateMeApp.Application.DTOs.FeedPost;
using Daylon.RateMeApp.Communication.Requests.FeedPost;
using Daylon.RateMeApp.Domain.Entities;

namespace Daylon.RateMeApp.Application.Interfaces.FeedPosts
{
    public interface IFeedPostService
    {
        // Get
        Task<IEnumerable<FeedPost>> GetAllPostsAsync();
        Task<FeedPostDTO> GetFeedPostByIdAsync(Guid id);

        // Post
        Task<FeedPostDTO> CreatePostAsync(RequestCreateFeedPostJson request);

        // Put
        Task<FeedPostDTO> UpdateFeedPostAsync(RequestUpdateFeedPostJson request);

        // Delete
        Task<bool> DeleteFeedPostAsync(Guid postId);
    }
}