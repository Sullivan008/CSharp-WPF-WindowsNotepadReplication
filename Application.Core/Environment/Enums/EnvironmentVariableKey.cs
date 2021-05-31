using System.Runtime.Serialization;

namespace Application.Core.Environment.Enums
{
    public enum EnvironmentVariableKey
    {
        [EnumMember(Value = "ASPNETCORE_ENVIRONMENT")]
        AspNetCoreEnvironment
    }
}
