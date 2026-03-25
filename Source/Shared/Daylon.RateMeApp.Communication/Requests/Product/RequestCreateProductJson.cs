using Daylon.RateMeApp.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace Daylon.RateMeApp.Communication.Requests.Product
{
    public class RequestCreateProductJson
    {
        // Product Properts
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double? Price { get; set; }

        // Rating
        public double? Rating { get; set; }

        // Image
        public string? ImageUrl { get; set; } = "hTps://www.exemplo.com\r\n";

        // Category/SubCategory
        public ProductCategoryEnum Category { get; set; }
        public ProductSubCategoryEnum SubCategory { get; set; }

        // Supplier
        public SupplierOptionsEnum? SupplierOption { get; set; }
        public string? SupplierPersonalizedName { get; set; }

    }
}
