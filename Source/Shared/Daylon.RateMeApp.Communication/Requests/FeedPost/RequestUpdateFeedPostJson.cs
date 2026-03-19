namespace Daylon.RateMeApp.Communication.Requests.FeedPost
{
    public class RequestUpdateFeedPostJson
    {
        public Guid Id { get; set; }
        public Guid? ProductId { get; set; }
        public bool? IsFavorite { get; set; }
    }
}