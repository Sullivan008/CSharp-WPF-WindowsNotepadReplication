using System;
using System.Drawing;
using Application.Client.Dialogs.ColorDialog.Enums;
using Application.Utilities.Guard;

namespace Application.Client.Dialogs.ColorDialog.Models
{
    public class ColorDialogResult
    {
        private readonly ColorDialogResultType? _colorDialogResultType;
        public ColorDialogResultType ColorDialogResultType
        {
            get
            {
                Guard.ThrowIfNull(_colorDialogResultType, nameof(ColorDialogResultType));

                return _colorDialogResultType!.Value;
            }

            init => _colorDialogResultType = value;
        }

        private readonly Color? _color;
        public Color Color
        {
            get
            {
                Guard.ThrowIfNull(_color, nameof(Color));

                return _color!.Value;
            }

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
