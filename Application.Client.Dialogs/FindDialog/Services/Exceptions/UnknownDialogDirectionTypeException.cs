using System;

namespace Application.Client.Dialogs.FindDialog.Services.Exceptions
{
    internal class UnknownDialogDirectionTypeException : Exception
    {
        public UnknownDialogDirectionTypeException()
        { }

        public UnknownDialogDirectionTypeException(string message) : base(message)
        { }

        public UnknownDialogDirectionTypeException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
