using System;
using Application.Client.Dialogs.GoToLineDialog.Enums;

namespace Application.Client.Dialogs.GoToLineDialog.Models
{
    public class GoToLineDialogResult
    {
        private readonly GoToLineDialogResultType? _goToLineDialogResultType;
        public GoToLineDialogResultType GoToLineDialogResultType
        {
            get => _goToLineDialogResultType ?? throw new ArgumentNullException(nameof(GoToLineDialogResultType), "The value cannot be null!");
            init => _goToLineDialogResultType = value;
        }

        private readonly int? _lineNumber;
        public int LineNumber
        {
            get => _lineNumber ?? throw new ArgumentNullException(nameof(LineNumber), "The value cannot be null!");
            init
            {
                if (!_goToLineDialogResultType.HasValue)
                {
                    throw new InvalidOperationException($"Without the result type of the go to line dialog, the {nameof(LineNumber)} property cannot be set!");
                }

                if (GoToLineDialogResultType == GoToLineDialogResultType.Cancel)
                {
                    throw new InvalidOperationException("It is not possible to set the line number when, the go to line dialog result type is cancel!");
                }

                _lineNumber = value;
            }
        }
    }
}
