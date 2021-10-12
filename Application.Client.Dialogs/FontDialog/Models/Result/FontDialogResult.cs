using System;
using Application.Client.Dialogs.FontDialog.Enums;

namespace Application.Client.Dialogs.FontDialog.Models.Result
{
    public class FontDialogResult
    {
        private readonly FontDialogResultType? _fontDialogResultType;
        public FontDialogResultType FontDialogResultType
        {
            get => _fontDialogResultType ?? throw new ArgumentNullException(nameof(_fontDialogResultType), "The value cannot be null!");
            init => _fontDialogResultType = value;
        }

        private readonly FontResult? _fontResult;
        public FontResult FontResult
        {
            get => _fontResult ?? throw new ArgumentNullException(nameof(FontResult), "The value cannot be null!");
            init
            {
                if (!_fontDialogResultType.HasValue)
                {
                    throw new InvalidOperationException($"Without the result type of the font dialog, the {nameof(FontResult)} property cannot be set!");
                }

                if (_fontDialogResultType.Value == FontDialogResultType.No && value != null)
                {
                    throw new InvalidOperationException("It is not possible to set the font when, the font dialog result type is cancelled!");
                }

                _fontResult = value;
            }
        }
    }
}
