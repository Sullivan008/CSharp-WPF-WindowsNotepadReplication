using System;

namespace Application.Client.Core.Dialogs.OpenFileDialog.Exceptions
{
    public class OpenFileDialogUnknownResultType : Exception
    {
        public OpenFileDialogUnknownResultType()
        { }

        public OpenFileDialogUnknownResultType(string message) : base(message)
        { }

        public OpenFileDialogUnknownResultType(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
