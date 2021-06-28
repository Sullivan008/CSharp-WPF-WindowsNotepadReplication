using System.Windows;
using System.Windows.Media;
using Application.Client.Infrastructure.ViewModels;

namespace Application.Client.Windows.Main.ViewModels
{
    public class FontOptionsViewModel : ViewModelBase
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
    }
}
