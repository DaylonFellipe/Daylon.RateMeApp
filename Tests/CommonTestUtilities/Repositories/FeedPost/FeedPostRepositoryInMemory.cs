using Daylon.RateMeApp.Domain.Interfaces.Repositories;
using Daylon.RateMeApp.Exceptions;
using Daylon.RateMeApp.Exceptions.ExceptionBases;

namespace CommonTestUtilities.Repositories.FeedPost
{
    public class FeedPostRepositoryInMemory : IFeedPostRepository
    {
        private readonly List<Daylon.RateMeApp.Domain.Entities.FeedPost> _posts = [];

        // Get
        public Task<IEnumerable<Daylon.RateMeApp.Domain.Entities.FeedPost>> GetAllPostsAsync()
        {
            var posts = _posts.AsEnumerable();
            return Task.FromResult(posts);
        }

        public Task<Daylon.RateMeApp.Domain.Entities.FeedPost?> GetFeedPostByIdAsync(Guid id)
        {
            var post = _posts.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(post);
        }

        public async Task<bool> ExisteFeedPostAsync(Guid id)
        {
            var post = await GetFeedPostByIdAsync(id) ??
                throw new RateMeAppException(string.Format((ResourceMessagesException.POST_ID_NO_FOUND), id));

            if (post is null)
                return false;

            else
                return true;
        }

        // Post
        public Task CreateFeedPostAsync(Daylon.RateMeApp.Domain.Entities.FeedPost post)
        {
            _posts.Add(post);
            return Task.CompletedTask;
        }

        // Put
        public Task UpdateFeedPostAsync(Daylon.RateMeApp.Domain.Entities.FeedPost post)
        {
            var exisitingPost = _posts.FirstOrDefault(post => post.Id == post.Id);

            if (exisitingPost is not null)
            {
                _posts.Remove(exisitingPost);
                _posts.Add(post);
            }

            return Task.CompletedTask;
        }

        // Delete
        public Task<bool> DeleteFeedPostAsync(Guid postId)
        {
            _posts.RemoveAll(x => x.Id == postId);
            return Task.FromResult(true);
        }
    }
}