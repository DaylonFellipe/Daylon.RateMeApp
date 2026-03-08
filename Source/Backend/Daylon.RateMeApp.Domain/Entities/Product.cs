using Daylon.RateMeApp.Domain.Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace Daylon.RateMeApp.Domain.Entity
{
    public class Product
    {
        // Product Properts
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double? Price { get; set; }

        // Rating
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public double? Rating { get; set; }

        // Image
        public string? ImageUrl { get; set; }

        // Category/SubCategory
        public ProductCategoryEnum Category { get; set; }
        public ProductSubCategoryEnum SubCategory { get; set; }

        // Supplier
        public SupplierOptionsEnum? SupplierOption { get; set; }
        public string? SupplierPersonalizedName { get; set; }
    }
}