using System;

namespace Application.Client.Dialogs.FontDialog.Exceptions
{
    public class FontDialogUnknownResultTypeException : Exception
    {
        public FontDialogUnknownResultTypeException()
        { }

        public FontDialogUnknownResultTypeException(string message) : base(message)
        { }

        public FontDialogUnknownResultTypeException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
