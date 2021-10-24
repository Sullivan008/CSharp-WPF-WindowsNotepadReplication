using System.Collections.Generic;
using System.Linq;

namespace Application.Utilities.Extensions
{
    public static class IReadOnlyListExtension
    {
        public static bool IsNullOrEmpty<T>(this IReadOnlyList<T>? @this)
        {
            return @this == null || !@this.Any();
        }
    }
}
