using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Microsoft.BusinessStore
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SeatAction
    {
        Assign,
        Reclaim
    }
}