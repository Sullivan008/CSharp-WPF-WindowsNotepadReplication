using System;
using System.Windows;
using Application.Client.Infrastructure.ViewModels;

namespace Application.Client.Windows.Main.ViewModels
{
    public class InputTextBoxViewModel : ViewModelBase
    {
        private string _content = string.Empty;
        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged();

                OnContentChanged();
            }
        }

        private string _selectedText = string.Empty;
        public string SelectedText
        {
            get => _selectedText;
            set
            {
                _selectedText = value;
                OnPropertyChanged();

                OnRefreshStatusBar();
            }
        }

        private int _caretIndex;
        public int CaretIndex
        {
            get => _caretIndex;
            set
            {
                _caretIndex = value;
                OnPropertyChanged();
            }
        }

        private TextWrapping _textWrapping = TextWrapping.NoWrap;
        public TextWrapping TextWrapping
        {
            get => _textWrapping;
            set
            {
                _textWrapping = value;
                OnPropertyChanged();
            }
        }

        private FontOptionsViewModel _fontOptions = new();
        public FontOptionsViewModel FontOptions
        {
            get => _fontOptions;
            set
            {
                _fontOptions = value;
                OnPropertyChanged();
            }
        }

        public delegate void OnContentChangedEventHandler(object sender, EventArgs e);

        public event OnContentChangedEventHandler OnContentChangedEvent;

        private void OnContentChanged(EventArgs eventArgs = null)
        {
            if (OnContentChangedEvent == null)
            {
                throw new ArgumentNullException(nameof(OnContentChangedEvent), "The value cannot be null!");
            }

            OnContentChangedEvent(this, eventArgs ?? EventArgs.Empty);
        }

        public delegate void OnRefreshStatusBarEventHandler(object sender, EventArgs e);

        public event OnRefreshStatusBarEventHandler OnRefreshStatusBarEvent;

        private void OnRefreshStatusBar(EventArgs eventArgs = null)
        {
            if (OnRefreshStatusBarEvent == null)
            {
                throw new ArgumentNullException(nameof(OnRefreshStatusBarEvent), "The value cannot be null!");
            }

            OnRefreshStatusBarEvent(this, eventArgs ?? EventArgs.Empty);
        }
    }
}
