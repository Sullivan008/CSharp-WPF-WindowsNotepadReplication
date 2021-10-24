using System.Windows;
using Application.Client.Common.ViewModels;

namespace Application.Client.Windows.Main.ViewModels.StatusBar
{
    public class StatusBarViewModel : ViewModelBase
    {
        public StatusBarViewModel()
        { }

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

        private int _ln = default(int) + 1;
        public int Ln
        {
            get => _ln;
            private set
            {
                _ln = value;
                OnPropertyChanged();
            }
        }

        private int _col = default(int) + 1;
        public int Col
        {
            get => _col;
            private set
            {
                _col = value;
                OnPropertyChanged();
            }
        }

        public void OnUpdateLn(int lineIndex)
        {
            Ln = lineIndex + 1;
        }

        public void OnUpdateCol(int columnIndex)
        {
            Col = columnIndex + 1;
        }
    }
}
