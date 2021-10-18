using System;

namespace Application.Client.Dialogs.FontDialog.Models.Result
{
    public class FontResult
    {
        private readonly string? _fontFamilyName;
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

        private readonly System.Drawing.FontStyle? _drawingFontStyle;
        public System.Drawing.FontStyle DrawingFontStyle
        {
            get => _drawingFontStyle ?? throw new ArgumentNullException(nameof(DrawingFontStyle), "The value cannot be null!");
            init => _drawingFontStyle = value;
        }

        private readonly System.Drawing.Color? _drawingFontColor;
        public System.Drawing.Color DrawingFontColor
        {
            get => _drawingFontColor ?? throw new ArgumentNullException(nameof(DrawingFontColor), "The value cannot be null!");
            init => _drawingFontColor = value;
        }
    }
}
