using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Utilities.Extensions
{
    public static class StringExtension
    {
        public static int IndexOfNth(this string @this, string searchedValue, int n)
        {
            if (string.IsNullOrEmpty(@this) || n < 1)
            {
                return -1;
            }

            int[] indexes = @this.IndexesOf(searchedValue);

            if (indexes != null && indexes.Length >= n)
            {
                return indexes[n - 1];
            }

            return -1;
        }

        private static int[] IndexesOf(this string @this, string searchedValue)
        {
            if (string.IsNullOrEmpty(searchedValue))
            {
                return null;
            }

            IList<int> indexes = new List<int>();
            int startIndex = 0;

            while (startIndex < @this.Length)
            {
                startIndex = @this.IndexOf(searchedValue, startIndex, StringComparison.CurrentCulture);

                if (startIndex >= 0)
                {
                    indexes.Add(startIndex);
                    startIndex += searchedValue.Length;
                }
                else
                {
                    break;
                }
            }

            return indexes.ToArray();
        }
    }
}
