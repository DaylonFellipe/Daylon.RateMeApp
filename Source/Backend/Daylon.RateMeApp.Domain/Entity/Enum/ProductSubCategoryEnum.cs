using System.Text.Json.Serialization;

namespace Daylon.RateMeApp.Domain.Entity.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum ProductSubCategoryEnum
    {
        Indefinite = 0,

        // Food
        Meals = 101,
        Grains = 102,
        Dairy = 103,
        Fruits = 104,
        Vegetables = 105,
        Meat = 106,
        Eggs = 107,
        MoreFood = 108,

        // Beverages
        Water = 201,
        SoftDrinks = 202,
        Juices = 203,
        Tea = 204,
        Coffee = 205,
        Milk = 206,
        Wine = 207,
        Beer = 208,
        Spirits = 209,
        MoreBeverages = 210,

        // Snacks
        Biscuits = 301,
        Chips = 302,
        Chocolate = 303,
        Candys = 304,
        Nuts = 305,
        MoreSnacks = 306,

        // Hygiene
        Soap = 401,
        ShampooAndConditioners = 402,
        OralHygiene = 403,
        Deodorants = 404,
        ToaletPaper = 405,
        MoreHygiene = 406,

        // Cleaning
        Detergents = 901,
        Disinfectants = 902,
        ClothsSponges = 903,
        TrashBags = 904,
        FloorCare = 905,
        AirFresheners = 906,
        MoreCleaning = 907,

        // PetProducts
        PetFood = 701,
        PetToys = 702,
        PetAccessories = 703,
        PetHygiene = 704,
        PetHealth = 705,
        MorePetProducts = 706,

        // Household
        Kitchenware = 801,
        Storage = 802,
        Tools = 803,
        Cleaning = 804,
        PaperProducts = 805,
        Laundry = 806,
        HomeMaintenance = 807,
        MoreHousehold = 808
    }
}
