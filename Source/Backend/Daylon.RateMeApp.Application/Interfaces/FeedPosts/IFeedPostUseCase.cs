using Daylon.RateMeApp.Communication.Requests.FeedPost;
using Daylon.RateMeApp.Domain.Entities;

namespace Daylon.RateMeApp.Application.Interfaces.FeedPosts
{
    public interface IFeedPostUseCase
    {
        // Post
        Task<FeedPost> ExecuteCreatePostAsync(RequestCreateFeedPostJson request);

        // Put
        Task<FeedPost> UpdatePostAsync(RequestUpdateFeedPostJson request);
    }
}