using System.Text.Json.Serialization;

namespace Daylon.RateMeApp.Domain.Entity.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum ProductCategoryEnum
    {
        Indefinite = 0,
        Food = 1,           
        Beverages = 2,      
        Snacks = 3,        
        Hygiene = 4,        
        Cleaning = 5,       
        BabyProducts = 6,   
        PetProducts = 7,    
        Household = 8
    }
}