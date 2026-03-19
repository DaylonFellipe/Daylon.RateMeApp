using Daylon.RateMeApp.Communication.Requests.FeedPost;

namespace Daylon.RateMeApp.Application.Interfaces.FeedPosts
{
    public interface IFeedPostUseCase
    {
        // Post
        Task<Domain.Entities.FeedPost> CreatePostAsync(RequestCreateFeedPostJson request);
    }
}