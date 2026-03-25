using Bogus;
using Daylon.RateMeApp.Communication.Requests.FeedPost;

namespace CommonTestUtilities.Requests.FeedPost
{
    public class RequestUpdateFeedPostJsonBuilder
    {
        public static RequestUpdateFeedPostJson Build(Guid postId, Guid? productId = null, bool? isFavorite = null)
        {
            return new Faker<RequestUpdateFeedPostJson>()
                .RuleFor(p => p.Id, f => postId)
                .RuleFor(p => p.ProductId, f => productId ?? null)
                .RuleFor(p => p.IsFavorite, f => isFavorite ?? null);
        }
    }
}