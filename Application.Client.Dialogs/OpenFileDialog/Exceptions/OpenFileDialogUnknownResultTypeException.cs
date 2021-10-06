using System;

namespace Application.Client.Dialogs.OpenFileDialog.Exceptions
{
    internal class OpenFileDialogUnknownResultTypeException : Exception
    {
        public OpenFileDialogUnknownResultTypeException()
        { }

        public OpenFileDialogUnknownResultTypeException(string message) : base(message)
        { }

        public OpenFileDialogUnknownResultTypeException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
