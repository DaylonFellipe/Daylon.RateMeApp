using Daylon.RateMeApp.Domain.Entity.Enum;
using Daylon.RateMeApp.Domain.Mappings;

namespace Daylon.RateMeApp.Domain.Helpers
{
    public static class SubCategoryHelper
    {
        public static ProductCategoryEnum GetProductCategory(ProductSubCategoryEnum subCategory)
        {
            if (SubCategoryMapping.Map.TryGetValue(subCategory, out var category))
                return category;

            else
                return ProductCategoryEnum.Indefinite;
        }

        public static bool IsValidSubCategory(ProductCategoryEnum category, ProductSubCategoryEnum subCategory)
        {
            return SubCategoryMapping.Map.TryGetValue(subCategory, out var mappedCategory)
                && mappedCategory == category;
        }
    }
}