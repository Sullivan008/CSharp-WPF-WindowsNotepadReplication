using System;

namespace Application.Client.Dialogs.GoToLineDialog.Exceptions
{
    public class GoToLineDialogUnknownResultTypeException : Exception
    {
        public GoToLineDialogUnknownResultTypeException()
        { }

        public GoToLineDialogUnknownResultTypeException(string message) : base(message)
        { }

        public GoToLineDialogUnknownResultTypeException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
