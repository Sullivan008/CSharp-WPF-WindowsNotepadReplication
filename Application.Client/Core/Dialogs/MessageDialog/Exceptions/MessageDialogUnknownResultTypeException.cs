﻿using System;

namespace Application.Client.Core.Dialogs.MessageDialog.Exceptions
{
    public class MessageDialogUnknownResultTypeException : Exception
    {
        public MessageDialogUnknownResultTypeException()
        { }

        public MessageDialogUnknownResultTypeException(string message) : base(message)
        { }

        public MessageDialogUnknownResultTypeException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
