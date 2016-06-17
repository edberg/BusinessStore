using Microsoft.AspNetCore.Http.Extensions;

namespace Microsoft.BusinessStore.Internal
{
    internal static class QueryString
    {
        public static QueryBuilder Create()
        {
            return new QueryBuilder();
        }
    }
}