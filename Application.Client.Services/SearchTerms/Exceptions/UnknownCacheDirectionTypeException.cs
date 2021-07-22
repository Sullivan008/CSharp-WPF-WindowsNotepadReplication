using System;

namespace Application.Client.Services.SearchTerms.Exceptions
{
    public class UnknownCacheDirectionTypeException : Exception
    {
        public UnknownCacheDirectionTypeException()
        { }

        public UnknownCacheDirectionTypeException(string message) : base(message)
        { }

        public UnknownCacheDirectionTypeException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
