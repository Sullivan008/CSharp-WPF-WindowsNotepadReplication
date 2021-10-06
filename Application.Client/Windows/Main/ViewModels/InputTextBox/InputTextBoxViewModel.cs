using System.Windows;
using System.Windows.Media;
using Application.Client.Common.ViewModels;
using Application.Client.Messenger.GenericMessages.InputTextBoxMessages;
using Application.Client.Services.DocInfo.Interfaces;

namespace Application.Client.Windows.Main.ViewModels.InputTextBox
{
    public class InputTextBoxViewModel : ViewModelBase
    {
        private readonly IDocInfoService _docInfoService;

        public InputTextBoxViewModel(TextOptionsViewModel textOptionsViewModel, IDocInfoService docInfoService)
        {
            _docInfoService = docInfoService;

            TextOptionsViewModel = textOptionsViewModel;
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

                GalaSoft.MvvmLight.Messaging.Messenger.Default.Send(new RefreshStatusBarMessage(this));
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

        private int _selectionLength;
        public int SelectionLength
        {
            get => _selectionLength;
            set
            {
                _selectionLength = value;
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

        private SolidColorBrush _background = new(Color.FromRgb(255, 255, 255));
        public SolidColorBrush Background
        {
            get => _background;
            set
            {
                _background = value;
                OnPropertyChanged();
            }
        }

        private TextOptionsViewModel _textOptionsViewModel;
        public TextOptionsViewModel TextOptionsViewModel
        {
            get => _textOptionsViewModel;
            set
            {
                _textOptionsViewModel = value;
                OnPropertyChanged();
            }
        }
    }
}
