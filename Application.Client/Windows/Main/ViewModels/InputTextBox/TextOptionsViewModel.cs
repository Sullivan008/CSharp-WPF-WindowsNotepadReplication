using System.Windows;
using System.Windows.Media;
using Application.Client.Common.ViewModels;

namespace Application.Client.Windows.Main.ViewModels.InputTextBox
{
    public class TextOptionsViewModel : ViewModelBase
    {
        private FontFamily _fontFamily = new("Consolas");
        public FontFamily FontFamily
        {
            get => _fontFamily;
            set
            {
                _fontFamily = value;
                OnPropertyChanged();
            }
        }

        private float _fontSize = default(float) + 12;
        public float FontSize
        {
            get => _fontSize;
            set
            {
                _fontSize = value;
                OnPropertyChanged();
            }
        }

        private FontWeight _fontWeight = FontWeights.Normal;
        public FontWeight FontWeight
        {
            get => _fontWeight;
            set
            {
                _fontWeight = value;
                OnPropertyChanged();
            }
        }

        private FontStyle _fontStyle = FontStyles.Normal;
        public FontStyle FontStyle
        {
            get => _fontStyle;
            set
            {
                _fontStyle = value;
                OnPropertyChanged();
            }
        }

        private TextDecorationCollection _textDecorations = new();
        public TextDecorationCollection TextDecorations
        {
            get => _textDecorations;
            set
            {
                _textDecorations = value;
                OnPropertyChanged();
            }
        }

        private SolidColorBrush _foreground = new(Color.FromRgb(0, 0, 0));
        public SolidColorBrush Foreground
        {
            get => _foreground;
            set
            {
                _foreground = value;
                OnPropertyChanged();
            }
        }
    }
}
