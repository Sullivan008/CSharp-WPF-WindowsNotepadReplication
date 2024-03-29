﻿using System;

namespace Application.Client.Dialogs.ColorDialog.Exceptions
{
    internal class ColorDialogUnknownResultTypeException : Exception
    {
        public ColorDialogUnknownResultTypeException()
        { }

        public ColorDialogUnknownResultTypeException(string message) : base(message)
        { }

        public ColorDialogUnknownResultTypeException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
