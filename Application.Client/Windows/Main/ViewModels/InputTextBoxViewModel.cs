using System;
using System.Windows;
using Application.Client.Infrastructure.ViewModels;
using Application.Client.Services.Interfaces;

namespace Application.Client.Windows.Main.ViewModels
{
    public class InputTextBoxViewModel : ViewModelBase
    {
        private readonly IDocInfoService _docInfoService;

        public InputTextBoxViewModel(TextOptionsViewModel textOptions, IDocInfoService docInfoService)
        {
            _docInfoService = docInfoService;

            TextOptions = textOptions;
        }

        private string _content = string.Empty;
        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged();

                if (!_docInfoService.IsModifiedDocument)
                {
                    _docInfoService.SetModifiedDocumentState();
                }
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

        private TextOptionsViewModel _textOptions;
        public TextOptionsViewModel TextOptions
        {
            get => _textOptions;
            set
            {
                _textOptions = value;
                OnPropertyChanged();
            }
        }

        public event OnRefreshStatusBarEventHandler OnRefreshStatusBarEvent;
        public delegate void OnRefreshStatusBarEventHandler(object sender, EventArgs e);

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
