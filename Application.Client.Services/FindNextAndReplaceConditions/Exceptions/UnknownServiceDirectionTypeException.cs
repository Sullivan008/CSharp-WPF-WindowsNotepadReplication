using System;

namespace Application.Client.Services.FindNextAndReplaceConditions.Exceptions
{
    internal class UnknownServiceDirectionTypeException : Exception
    {
        public UnknownServiceDirectionTypeException()
        { }

        public UnknownServiceDirectionTypeException(string message) : base(message)
        { }

        public UnknownServiceDirectionTypeException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
