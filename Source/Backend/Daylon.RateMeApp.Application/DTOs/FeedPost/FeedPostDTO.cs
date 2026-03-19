namespace Daylon.RateMeApp.Application.DTOs.FeedPost
{
    public class FeedPostDTO
    {
        // Post Properts
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public bool IsFavorite { get; set; }
    }
}