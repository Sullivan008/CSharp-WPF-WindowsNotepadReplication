using System;

namespace Application.Client.Services.SearchTerms.Exceptions
{
    public class UnknownDirectionTypeException : Exception
    {
        public UnknownDirectionTypeException()
        { }

        public UnknownDirectionTypeException(string message) : base(message)
        { }

        public UnknownDirectionTypeException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
