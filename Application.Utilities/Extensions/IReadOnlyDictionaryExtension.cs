using System.Collections.Generic;
using System.Linq;

namespace Application.Utilities.Extensions
{
    public static class IReadOnlyDictionaryExtension
    {
        public static bool IsNullOrEmpty<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary)
        {
            return dictionary == null || !dictionary.Any();
        }
    }
}
