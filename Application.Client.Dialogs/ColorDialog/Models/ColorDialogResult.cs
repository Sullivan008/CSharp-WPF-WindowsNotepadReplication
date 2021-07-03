using System;
using System.Drawing;
using Application.Client.Dialogs.ColorDialog.Enums;

namespace Application.Client.Dialogs.ColorDialog.Models
{
    public class ColorDialogResult
    {
        private readonly ColorDialogResultType? _colorDialogResultType;
        public ColorDialogResultType ColorDialogResultType
        {
            get => _colorDialogResultType ?? throw new ArgumentNullException(nameof(ColorDialogResultType), "The value cannot be null!");
            init => _colorDialogResultType = value;
        }

        private readonly Color? _color;
        public Color Color
        {
            get => _color ?? throw new ArgumentNullException(nameof(Color), "The value cannot be null!");
            init
            {
                if (!_colorDialogResultType.HasValue)
                {
                    throw new InvalidOperationException($"Without the result type of the color dialog, the {nameof(Color)} property cannot be set!");
                }

                if (_colorDialogResultType.Value == ColorDialogResultType.No)
                {
                    throw new InvalidOperationException("It is not possible to set the color when, the font dialog result type is no!");
                }

                _color = value;
            }
        }
    }
}
