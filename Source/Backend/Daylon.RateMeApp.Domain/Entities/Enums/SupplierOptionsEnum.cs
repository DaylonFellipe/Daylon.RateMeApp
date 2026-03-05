using System.Text.Json.Serialization;

namespace Daylon.RateMeApp.Domain.Entity.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum SupplierOptionsEnum
    {
        Indefinite = 0,
        Continente = 1,
        PingoDoce = 2,
        Auchan = 3,
        Lidl = 4,
        Minipreco = 5,
        Intermarche = 6,
        Aldi = 7,
        Mercadona = 8
    }
}