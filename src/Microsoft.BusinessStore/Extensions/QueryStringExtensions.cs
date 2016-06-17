using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Extensions;

namespace Microsoft.BusinessStore.Extensions
{
    public static class QueryStringExtensions
    {
        public static void AddParameter(this QueryBuilder query, string name, int? value)
        {
            if (value != null) query.Add(name, value.ToString());
        }

        public static void AddParameter(this QueryBuilder query, string name, string value)
        {
            if (value != null) query.Add(name, value);
        }

        public static void AddParameter(this QueryBuilder query, string name, DateTime? value)
        {
            if (value != null) query.Add(name, value.Value.ToJson());
        }

        public static void AddParameters<T>(this QueryBuilder query, string name, List<T> values)
        {
            if (values != null) values.ForEach(value => query.Add(name, value.ToString()));
        }
    }
}