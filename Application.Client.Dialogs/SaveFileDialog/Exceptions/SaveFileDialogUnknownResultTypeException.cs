using System;

namespace Application.Client.Dialogs.SaveFileDialog.Exceptions
{
    internal class SaveFileDialogUnknownResultTypeException : Exception
    {
        public SaveFileDialogUnknownResultTypeException()
        { }

        public SaveFileDialogUnknownResultTypeException(string message) : base(message)
        { }

        public SaveFileDialogUnknownResultTypeException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
