namespace Daylon.RateMeApp.Communication.Requests.FeedPost
{
    public class RequestCreateFeedPostJson
    {
        public Guid ProductId { get; set; } = new();
        public bool IsFavorite { get; set; }
    }
}