using System.Collections.Generic;
using System.Linq;

namespace Application.Utilities.Extensions
{
    public static class IReadOnlyDictionaryExtension
    {
        public static bool IsNullOrEmpty<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue>? @this)
        {
            return @this == null || !@this.Any();
        }
    }
}
