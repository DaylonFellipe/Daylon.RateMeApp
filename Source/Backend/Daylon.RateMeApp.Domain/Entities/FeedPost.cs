using Daylon.RateMeApp.Domain.Entities;

namespace Daylon.RateMeApp.Domain.Entities
{
    public class FeedPost
    {
        // FeedPost Properties
        public Guid Id { get; set; }
        public Product Product { get; set; } = new Product();
        public bool IsFavorite { get; set; }
    }
}