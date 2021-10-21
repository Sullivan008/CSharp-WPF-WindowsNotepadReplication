using System;

namespace Application.Client.Dialogs.FindDialog.Services.Exceptions
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
