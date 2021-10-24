using System;
using System.Collections.Generic;
using Application.Utilities.Extensions;

namespace Application.Utilities.Guard
{
    public static class Guard
    {
        public static void ThrowIfNull<T>(T input, string parameterName, string? message = null)
        {
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.String:
                    {
                        ThrowIfNullOrWhitespace(input as string, parameterName, message);
                        break;
                    }
                default:
                    {
                        if (input is null)
                        {
                            throw new ArgumentNullException(parameterName, message ?? "The value cannot be null!");
                        }

                        break;
                    }
            }
        }

        public static void ThrowIfNullOrEmpty<TKey, TValue>(IReadOnlyDictionary<TKey, TValue>? input, string parameterName, string? message = null)
        {
            if (input.IsNullOrEmpty())
            {
                throw new ArgumentNullException(parameterName, message ?? "The value cannot be null!");
            }
        }

        public static void ThrowIfNullOrEmpty<T>(IReadOnlyList<T>? input, string parameterName, string? message = null)
        {
            if (input.IsNullOrEmpty())
            {
                throw new ArgumentNullException(parameterName, message ?? "The value cannot be null!");
            }
        }

        public static void ThrowIfNullOrWhitespace(string? input, string parameterName, string? message = null)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException(parameterName, message ?? "The value cannot be null!");
            }
        }
    }
}
