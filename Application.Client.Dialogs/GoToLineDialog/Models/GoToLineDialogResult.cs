using System;
using Application.Client.Dialogs.GoToLineDialog.Enums;
using Application.Utilities.Guard;

namespace Application.Client.Dialogs.GoToLineDialog.Models
{
    public class GoToLineDialogResult
    {
        private readonly GoToLineDialogResultType? _goToLineDialogResultType;
        public GoToLineDialogResultType GoToLineDialogResultType
        {
            get
            {
                Guard.ThrowIfNull(_goToLineDialogResultType, nameof(GoToLineDialogResultType));

                return _goToLineDialogResultType!.Value;
            }

            init => _goToLineDialogResultType = value;
        }

        private readonly int? _lineNumber;
        public int LineNumber
        {
            get
            {
                Guard.ThrowIfNull(_lineNumber, nameof(LineNumber));

                return _lineNumber!.Value;
            }

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
