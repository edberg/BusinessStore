using System;
using Newtonsoft.Json;

namespace Microsoft.BusinessStore
{
    public static class JsonExtensions
    {
        public static string ToJson(this DateTime date)
        {
            return JsonConvert.SerializeObject(date);
        }
    }
}