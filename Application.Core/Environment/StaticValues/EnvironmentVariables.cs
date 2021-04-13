using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Application.Core.Environment.StaticValues.Enums;

namespace Application.Core.Environment.StaticValues
{
    public static class EnvironmentVariables
    {
        private static readonly ReadOnlyDictionary<EnvironmentVariableKey, string> EnvironmentVariableKeys;

        static EnvironmentVariables()
        {
            EnvironmentVariableKeys = new ReadOnlyDictionary<EnvironmentVariableKey, string>(new Dictionary<EnvironmentVariableKey, string>
            {
                { EnvironmentVariableKey.AspNetCoreEnvironment, "ASPNETCORE_ENVIRONMENT" }
            });
        }

        public static string GetEnvironmentVariableKey(EnvironmentVariableKey key)
        {
            EnvironmentVariableKeys.TryGetValue(key, out string result);

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result), $@"The following Environment Variable Key does not exist with this key. {nameof(key).ToUpper()}: {key}");
            }

            return result;
        }
    }
}
