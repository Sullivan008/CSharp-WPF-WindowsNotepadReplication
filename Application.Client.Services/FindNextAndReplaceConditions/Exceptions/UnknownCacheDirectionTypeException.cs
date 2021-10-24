using System;

namespace Application.Client.Services.FindNextAndReplaceConditions.Exceptions
{
    internal class UnknownCacheDirectionTypeException : Exception
    {
        public UnknownCacheDirectionTypeException()
        { }

        public UnknownCacheDirectionTypeException(string message) : base(message)
        { }

        public UnknownCacheDirectionTypeException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
