using Daylon.RateMeApp.Domain.Entity.Enum;

namespace Daylon.RateMeApp.Domain.Entity
{
    public class SubCategory
    {
        // SubCategory Properties
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid CategoryId { get; set; }
        public ProductCategoryEnum Category { get; set; }
        public ICollection<Product> Products { get; set; } = [];
    }
}