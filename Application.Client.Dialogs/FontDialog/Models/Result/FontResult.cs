using System;
using System.Windows;
using System.Windows.Media;

namespace Application.Client.Dialogs.FontDialog.Models.Result
{
    public class FontResult
    {
        private readonly string _fontFamilyName;
        public string FontFamilyName
        {
            private get
            {
                return !string.IsNullOrWhiteSpace(_fontFamilyName)
                    ? _fontFamilyName
                    : throw new ArgumentNullException(nameof(FontFamilyName), "The value cannot be null!");
            }

            init => _fontFamilyName = value;
        }

        private readonly float? _drawingFontSize;
        public float DrawingFontSize
        {
            private get
            {
                return _drawingFontSize ?? throw new ArgumentNullException(nameof(DrawingFontSize), "The value cannot be null!");
            }

            init => _drawingFontSize = value;
        }

        private readonly System.Drawing.FontStyle? _drawingFontStyle;
        public System.Drawing.FontStyle DrawingFontStyle
        {
            private get
            {
                return _drawingFontStyle ?? throw new ArgumentNullException(nameof(DrawingFontStyle), "The value cannot be null!");
            }

            init => _drawingFontStyle = value;
        }

        public FontFamily FontFamily => new(FontFamilyName);

        public float FontSize => (float)(DrawingFontSize * 96.0 / 72.0);

        public FontStyle FontStyle => (DrawingFontStyle & System.Drawing.FontStyle.Italic) != 0 ? FontStyles.Italic : FontStyles.Normal;

        public FontWeight FontWeight => (DrawingFontStyle & System.Drawing.FontStyle.Bold) != 0 ? FontWeights.Bold : FontWeights.Regular;

    }
}
