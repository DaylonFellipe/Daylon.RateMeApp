using Daylon.RateMeApp.Domain.Entities;
using Daylon.RateMeApp.Domain.Interfaces.Repositories;
using Daylon.RateMeApp.Exceptions;
using Daylon.RateMeApp.Exceptions.ExceptionBases;
using Microsoft.EntityFrameworkCore;

namespace Daylon.RateMeApp.Infrastructure.DataAccess.Repositories
{
    public class FeedPostRepository(RateMeAppDbContext dbContext) : IFeedPostRepository
    {
        private readonly RateMeAppDbContext _dbContext = dbContext;

        // Db
        private async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        // Get
        public async Task<IEnumerable<FeedPost>> GetAllPostsAsync()
        {
            var postsList = await _dbContext.FeedPosts.Include(p => p.Product).ToListAsync();

            var countList = postsList.Count();

            if (postsList == null || postsList.Count == 0)
                throw new RateMeAppException(ResourceMessagesException.POST_NO_FOUND);

            foreach (var post in postsList)
            {
                var productId = (post.Product?.Id) ?? throw new RateMeAppException(ResourceMessagesException.POST_PRODUCT_EMPTY);

                var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId)
                    ?? throw new RateMeAppException(string.Format(ResourceMessagesException.PRODUCT_ID_NO_FOUND, productId));
            }

            return postsList;
        }
    }
}