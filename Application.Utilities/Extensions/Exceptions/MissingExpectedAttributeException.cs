using System;

namespace Application.Utilities.Extensions.Exceptions
{
    public class MissingExpectedAttributeException : Exception
    {
        public MissingExpectedAttributeException()
        { }

        public MissingExpectedAttributeException(string message) : base(message)
        { }

        public MissingExpectedAttributeException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
