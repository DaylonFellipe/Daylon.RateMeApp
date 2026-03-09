using Daylon.RateMeApp.Domain.Entity.Enum;

namespace Daylon.RateMeApp.Application.DTOs.Product
{
    public class ProductDTO
    {
        // Product Properts
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }

        // Rating
        public double Rating { get; set; }

        // Category/SubCategory
        public ProductCategoryEnum Category { get; set; }
        public ProductSubCategoryEnum SubCategory { get; set; }

        // Supplier
        public string SupplierName { get; set; } = string.Empty;
    }
}