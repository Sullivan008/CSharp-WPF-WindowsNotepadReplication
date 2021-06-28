using System;

namespace Application.Client.Dialogs.FontDialog.Exceptions
{
    public class UnknownFontException : Exception
    {
        public UnknownFontException()
        { }

        public UnknownFontException(string message) : base(message)
        { }

        public UnknownFontException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
