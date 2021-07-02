using System;
using System.Drawing;

namespace Application.Client.Windows.Main.EventArguments
{
    public class RefreshTextOptionsByDrawingFontEventArgs : EventArgs
    {
        private readonly string _fontFamilyName;
        public string FontFamilyName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_fontFamilyName))
                {
                    throw new ArgumentNullException(nameof(FontFamilyName), "The value cannot be null!");
                }

                return _fontFamilyName;
            }

            init => _fontFamilyName = value;
        }

        private readonly float? _drawingFontSize;
        public float DrawingFontSize
        {
            get => _drawingFontSize ?? throw new ArgumentNullException(nameof(DrawingFontSize), "The value cannot be null!");
            init => _drawingFontSize = value;
        }

        private readonly FontStyle? _drawingFontStyle;
        public FontStyle DrawingFontStyle
        {
            get => _drawingFontStyle ?? throw new ArgumentNullException(nameof(DrawingFontStyle), "The value cannot be null!");
            init => _drawingFontStyle = value;
        }
    }
}
