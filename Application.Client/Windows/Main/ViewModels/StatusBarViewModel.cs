using System.Windows;
using Application.Client.Infrastructure.ViewModels;

namespace Application.Client.Windows.Main.ViewModels
{
    public class StatusBarViewModel : ViewModelBase
    {
        private Visibility _visibility = Visibility.Visible;
        public Visibility Visibility
        {
            get => _visibility;
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }

        private int _length;
        public int Length
        {
            get => _length;
            private set
            {
                _length = value;
                OnPropertyChanged();
            }
        }

        private int _lines = default(int) + 1;
        public int Lines
        {
            get => _lines;
            private set
            {
                _lines = value;
                OnPropertyChanged();
            }
        }

        public void RefreshOutputData(string content)
        {
            Length = GetContentLength(content);
            Lines = GetContentLines(content);
        }

        private static int GetContentLength(string content) => content.Length;

        private static int GetContentLines(string content)
        {
            const string ROW_SEPARATOR = "\n";

            return content.Split(ROW_SEPARATOR).Length;
        }
    }
}
