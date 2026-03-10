using Daylon.RateMeApp.Domain.Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace Daylon.RateMeApp.Application.DTOs.Product
{
    public class ProductDTO
    {
        // Product Properts
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }

        // Rating
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public double Rating { get; set; }

        // Category/SubCategory
        public ProductCategoryEnum Category { get; set; }
        public ProductSubCategoryEnum SubCategory { get; set; }

        // Supplier
        public string SupplierName { get; set; } = string.Empty;
    }
}