using System;

namespace Application.Client.Core.Dialogs.OpenFileDialog.Exceptions
{
    public class OpenFileDialogUnknownResultTypeException : Exception
    {
        public OpenFileDialogUnknownResultTypeException()
        { }

        public OpenFileDialogUnknownResultTypeException(string message) : base(message)
        { }

        public OpenFileDialogUnknownResultTypeException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
