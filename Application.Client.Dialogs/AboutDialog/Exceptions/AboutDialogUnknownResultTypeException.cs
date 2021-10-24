using System;

namespace Application.Client.Dialogs.AboutDialog.Exceptions
{
    public class AboutDialogUnknownResultTypeException : Exception
    {
        public AboutDialogUnknownResultTypeException()
        { }

        public AboutDialogUnknownResultTypeException(string message) : base(message)
        { }

        public AboutDialogUnknownResultTypeException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
