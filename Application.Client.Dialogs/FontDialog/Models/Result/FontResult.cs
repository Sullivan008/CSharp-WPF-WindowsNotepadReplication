using Application.Utilities.Guard;

namespace Application.Client.Dialogs.FontDialog.Models.Result
{
    public class FontResult
    {
        private readonly string? _fontFamilyName;
        public string FontFamilyName
        {
            get
            {
                Guard.ThrowIfNullOrWhitespace(_fontFamilyName, nameof(FontFamilyName));
                
                return _fontFamilyName!;
            }

            init => _fontFamilyName = value;
        }

        private readonly float? _drawingFontSize;
        public float DrawingFontSize
        {
            get
            {
                Guard.ThrowIfNull(_drawingFontSize, nameof(DrawingFontSize));

                return _drawingFontSize!.Value;
            }

            init => _drawingFontSize = value;
        }

        private readonly System.Drawing.FontStyle? _drawingFontStyle;
        public System.Drawing.FontStyle DrawingFontStyle
        {
            get
            {
                Guard.ThrowIfNull(_drawingFontStyle, nameof(DrawingFontStyle));

                return _drawingFontStyle!.Value;
            }

            init => _drawingFontStyle = value;
        }

        private readonly System.Drawing.Color? _drawingFontColor;
        public System.Drawing.Color DrawingFontColor
        {
            get
            {
                Guard.ThrowIfNull(_drawingFontColor, nameof(DrawingFontColor));

                return _drawingFontColor!.Value;
            }
            
            init => _drawingFontColor = value;
        }
    }
}
