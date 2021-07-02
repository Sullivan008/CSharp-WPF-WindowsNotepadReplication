using System.Windows;
using System.Windows.Media;

namespace Application.Client.Dialogs.FontDialog.Models.Options
{
    public class FontOptions
    {
        private readonly string _fontFamilyName;
        public string FontFamilyName
        {
            get
            {
                const string DEFAULT_FONT_NAME = "Consolas";
                
                return string.IsNullOrWhiteSpace(_fontFamilyName) ? DEFAULT_FONT_NAME : _fontFamilyName;
            }

            init => _fontFamilyName = value;
        }

        public float FontSize { get; init; } = 16;

        public FontStyle WindowsFontStyle { get; init; } = FontStyles.Normal;

        public FontWeight WindowsFontWeight { get; init; } = FontWeights.Regular;

        public TextDecorationCollection WindowsTextDecorations { get; init; } = new();

        public Color MediaFontColor { get; init; } = Color.FromRgb(0, 0, 0);
    }
}
