using System.Collections.Generic;
using System.Linq;

namespace Application.Core.Extensions
{
    public static class IReadOnlyListExtension
    {
        public static bool IsNullOrEmpty<T>(this IReadOnlyList<T> list)
        {
            return list == null || !list.Any();
        }
    }
}
