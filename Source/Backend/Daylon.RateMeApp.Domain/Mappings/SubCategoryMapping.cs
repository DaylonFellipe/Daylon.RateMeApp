using Daylon.RateMeApp.Domain.Entities.Enum;

namespace Daylon.RateMeApp.Domain.Mappings
{
    public static class SubCategoryMapping
    {
        public static readonly Dictionary<ProductSubCategoryEnum, ProductCategoryEnum> Map = new()
        {
            // Indefinite
            {ProductSubCategoryEnum.Indefinite, ProductCategoryEnum.Indefinite},

            // Food
            {ProductSubCategoryEnum.Meals, ProductCategoryEnum.Food},
            {ProductSubCategoryEnum.Grains, ProductCategoryEnum.Food},
            {ProductSubCategoryEnum.Dairy, ProductCategoryEnum.Food},
            {ProductSubCategoryEnum.Fruits, ProductCategoryEnum.Food},
            {ProductSubCategoryEnum.Vegetables, ProductCategoryEnum.Food},
            {ProductSubCategoryEnum.Meat, ProductCategoryEnum.Food},
            {ProductSubCategoryEnum.Eggs, ProductCategoryEnum.Food},
            {ProductSubCategoryEnum.MoreFood, ProductCategoryEnum.Food},

            // Beverages
            {ProductSubCategoryEnum.Water, ProductCategoryEnum.Beverages},
            {ProductSubCategoryEnum.SoftDrinks, ProductCategoryEnum.Beverages},
            {ProductSubCategoryEnum.Juices, ProductCategoryEnum.Beverages},
            {ProductSubCategoryEnum.Tea, ProductCategoryEnum.Beverages},
            {ProductSubCategoryEnum.Coffee, ProductCategoryEnum.Beverages},
            {ProductSubCategoryEnum.Milk, ProductCategoryEnum.Beverages},
            {ProductSubCategoryEnum.Wine, ProductCategoryEnum.Beverages},
            {ProductSubCategoryEnum.Beer, ProductCategoryEnum.Beverages},
            {ProductSubCategoryEnum.Spirits, ProductCategoryEnum.Beverages},
            {ProductSubCategoryEnum.MoreBeverages, ProductCategoryEnum.Beverages},

            // Snacks
            {ProductSubCategoryEnum.Biscuits, ProductCategoryEnum.Snacks},
            {ProductSubCategoryEnum.Chips, ProductCategoryEnum.Snacks},
            {ProductSubCategoryEnum.Chocolate, ProductCategoryEnum.Snacks},
            {ProductSubCategoryEnum.Candys, ProductCategoryEnum.Snacks},
            {ProductSubCategoryEnum.Nuts, ProductCategoryEnum.Snacks},
            {ProductSubCategoryEnum.MoreSnacks, ProductCategoryEnum.Snacks},

            // Hygiene
            {ProductSubCategoryEnum.Soap, ProductCategoryEnum.Hygiene},
            {ProductSubCategoryEnum.ShampooAndConditioners, ProductCategoryEnum.Hygiene},
            {ProductSubCategoryEnum.OralHygiene, ProductCategoryEnum.Hygiene},
            {ProductSubCategoryEnum.Deodorants, ProductCategoryEnum.Hygiene},
            {ProductSubCategoryEnum.ToaletPaper, ProductCategoryEnum.Hygiene},
            {ProductSubCategoryEnum.MoreHygiene, ProductCategoryEnum.Hygiene},

            // Cleaning
            {ProductSubCategoryEnum.Detergents, ProductCategoryEnum.Cleaning},
            {ProductSubCategoryEnum.Disinfectants, ProductCategoryEnum.Cleaning},
            {ProductSubCategoryEnum.ClothsSponges, ProductCategoryEnum.Cleaning},
            {ProductSubCategoryEnum.TrashBags, ProductCategoryEnum.Cleaning},
            {ProductSubCategoryEnum.FloorCare, ProductCategoryEnum.Cleaning},
            {ProductSubCategoryEnum.AirFresheners, ProductCategoryEnum.Cleaning},
            {ProductSubCategoryEnum.MoreCleaning, ProductCategoryEnum.Cleaning},

            // PetProducts
            {ProductSubCategoryEnum.PetFood, ProductCategoryEnum.PetProducts},
            {ProductSubCategoryEnum.PetToys, ProductCategoryEnum.PetProducts},
            {ProductSubCategoryEnum.PetAccessories, ProductCategoryEnum.PetProducts},
            {ProductSubCategoryEnum.PetHygiene, ProductCategoryEnum.PetProducts},
            {ProductSubCategoryEnum.PetHealth, ProductCategoryEnum.PetProducts},
            {ProductSubCategoryEnum.MorePetProducts, ProductCategoryEnum.PetProducts},

            // Household
            {ProductSubCategoryEnum.Kitchenware, ProductCategoryEnum.Household},
            {ProductSubCategoryEnum.Storage, ProductCategoryEnum.Household},
            {ProductSubCategoryEnum.Tools, ProductCategoryEnum.Household},
            {ProductSubCategoryEnum.Cleaning, ProductCategoryEnum.Household},
            {ProductSubCategoryEnum.PaperProducts, ProductCategoryEnum.Household},
            {ProductSubCategoryEnum.Laundry, ProductCategoryEnum.Household},
            {ProductSubCategoryEnum.HomeMaintenance, ProductCategoryEnum.Household},
            {ProductSubCategoryEnum.MoreHousehold, ProductCategoryEnum.Household},
        };
    }
}