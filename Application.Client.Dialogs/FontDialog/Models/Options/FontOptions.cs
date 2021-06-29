using System;
using System.Drawing;
using System.Linq;
using System.Windows;
using Application.Client.Dialogs.FontDialog.Exceptions;

namespace Application.Client.Dialogs.FontDialog.Models.Options
{
    public class FontOptions
    {
        private readonly string _fontFamilyName;
        public string FontFamilyName
        {
            private get
            {
                const string DEFAULT_FONT_NAME = "Consolas";
                
                return string.IsNullOrWhiteSpace(_fontFamilyName) ? DEFAULT_FONT_NAME : _fontFamilyName;
            }

            init => _fontFamilyName = value;
        }

        private readonly float? _mediaFontSize;
        public float MediaFontSize
        {
            private get
            {
                const float DEFAULT_FONT_SIZE = 16;

                return _mediaFontSize ?? DEFAULT_FONT_SIZE;
            }

            init => _mediaFontSize = value;
        }

        private readonly System.Windows.FontStyle? _mediaFontStyle;
        public System.Windows.FontStyle MediaFontStyle
        {
            private get => _mediaFontStyle ?? FontStyles.Normal;
            init => _mediaFontStyle = value;
        }

        private readonly FontWeight? _mediaFontWeight;
        public FontWeight MediaFontWeight
        {
            private get => _mediaFontWeight ?? FontWeights.Regular;
            init => _mediaFontWeight = value;
        }

        public TextDecorationCollection TextDecorations { private get; init; } = new();

        public FontFamily FontFamily
        {
            get
            {
                try
                {
                    return new FontFamily(FontFamilyName);
                }
                catch (ArgumentException)
                {
                    throw new UnknownFontException($"The following font does not exist or not available on the source machine! Please reinstall the following font type: {FontFamilyName}");
                }
            }
        }

        public float FontSize => (float)(MediaFontSize * 72.0 / 96.0);

        public System.Drawing.FontStyle FontStyle
        {
            get
            {
                System.Drawing.FontStyle result;

                result = MediaFontStyle == FontStyles.Italic ? System.Drawing.FontStyle.Italic : System.Drawing.FontStyle.Regular;
                result ^= MediaFontWeight == FontWeights.Bold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular;

                if (TextDecorations.Any(x => x.Location == TextDecorationLocation.Strikethrough))
                {
                    result ^= System.Drawing.FontStyle.Strikeout;
                }

                if (TextDecorations.Any(x => x.Location == TextDecorationLocation.Underline))
                {
                    result ^= System.Drawing.FontStyle.Underline;
                }

                return result;
            }
        }
    }
}
