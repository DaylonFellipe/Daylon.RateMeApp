using Bogus;
using Daylon.RateMeApp.Communication.Requests.FeedPost;

namespace CommonTestUtilities.Requests.FeedPost
{
    public class RequestCreateFeedPostJsonBuilder
    {
        public static RequestCreateFeedPostJson Build(Guid? productId = null, bool? isFavorite = null)
        {
            return new Faker<RequestCreateFeedPostJson>()
                .RuleFor(p => p.ProductId, f => productId ?? Guid.NewGuid())
                .RuleFor(p => p.IsFavorite, f => isFavorite ?? f.Random.Bool());
        }
    }
}