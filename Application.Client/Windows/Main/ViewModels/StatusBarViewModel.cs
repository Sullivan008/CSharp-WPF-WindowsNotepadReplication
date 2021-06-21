using System;
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

        private readonly int? _length = default(int);
        public int Length
        {
            get
            {
                if (!_length.HasValue)
                {
                    throw new ArgumentNullException(nameof(Length), "The value cannot be null!");
                }

                return _length.Value;
            }

            init => _length = value;
        }

        private readonly int? _lines = default(int) + 1;
        public int Lines
        {
            get
            {
                if (!_lines.HasValue)
                {
                    throw new ArgumentNullException(nameof(Lines), "The value cannot be null!");
                }

                return _lines.Value;
            }

            init => _lines = value;
        }
    }
}
