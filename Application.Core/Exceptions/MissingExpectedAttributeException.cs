using System;

namespace Application.Core.Exceptions
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
