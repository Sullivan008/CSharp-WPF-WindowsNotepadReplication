using System.Windows.Input;
using System.Windows.Threading;
using Application.Client.Dialogs.ColorDialog.Interfaces;
using Application.Client.Dialogs.FindDialog.Interfaces;
using Application.Client.Dialogs.FontDialog.Interfaces;
using Application.Client.Dialogs.GoToLineDialog.Interfaces;
using Application.Client.Dialogs.MessageDialog.Interfaces;
using Application.Client.Dialogs.OpenFileDialog.Interfaces;
using Application.Client.Dialogs.SaveFileDialog.Interfaces;
using Application.Client.Infrastructure.ViewModels;
using Application.Client.Services.Interfaces;
using Application.Client.Windows.Main.Commands.EditMenu;
using Application.Client.Windows.Main.Commands.FileMenu;
using Application.Client.Windows.Main.Commands.FormatMenu;
using Application.Client.Windows.Main.Commands.Shared;
using Application.Client.Windows.Main.Commands.ViewMenu;
using Application.Utilities.FileReader.Interfaces;
using Application.Utilities.FileWriter.Interfaces;

namespace Application.Client.Windows.Main.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IFontDialog _fontDialog;

        private readonly IFindDialog _findDialog;

        private readonly IColorDialog _colorDialog;

        private readonly IMessageDialog _messageDialog;

        private readonly IOpenFileDialog _openFileDialog;

        private readonly ISaveFileDialog _saveFileDialog;

        private readonly IGoToLineDialog _goToLineDialog;

        private readonly ITextFileWriter _textFileWriter;

        private readonly ITextFileReader _textFileReader;

        private readonly IDocInfoService _docInfoService;
        
        public MainWindowViewModel(InputTextBoxViewModel inputTextBox, StatusBarViewModel statusBar, IFontDialog fontDialog, IFindDialog findDialog, IColorDialog colorDialog, IMessageDialog messageDialog,
            IOpenFileDialog openFileDialog, ISaveFileDialog saveFileDialog, IGoToLineDialog goToLineDialog, ITextFileWriter textFileWriter, ITextFileReader textFileReader, IDocInfoService docInfoService)
        {
            _fontDialog = fontDialog;
            _findDialog = findDialog;
            _colorDialog = colorDialog;
            _messageDialog = messageDialog;
            _openFileDialog = openFileDialog;
            _saveFileDialog = saveFileDialog;
            _goToLineDialog = goToLineDialog;
            _textFileWriter = textFileWriter;
            _textFileReader = textFileReader;
            _docInfoService = docInfoService;

            StatusBar = statusBar;
            InputTextBox = inputTextBox;
            InputTextBox.OnRefreshStatusBarEvent += (sender, _) => { Dispatcher.CurrentDispatcher.Invoke(() => StatusBar.RefreshOutputData(((InputTextBoxViewModel)sender).Content)); };
        }

        private string _windowTitle;
        public string WindowTitle
        {
            get
            {
                const string WINDOW_TITLE_POSTFIX = " - Notepad";

                return $"{_windowTitle ?? _docInfoService.UsedFileNameWithoutExtension}{WINDOW_TITLE_POSTFIX}";
            }
            set
            {
                _windowTitle = value;
                OnPropertyChanged();
            }
        }

        private static InputTextBoxViewModel _inputTextBox;
        public InputTextBoxViewModel InputTextBox
        {
            get => _inputTextBox;
            set
            {
                _inputTextBox = value;
                OnPropertyChanged();
            }
        }

        private StatusBarViewModel _statusBar;
        public StatusBarViewModel StatusBar
        {
            get => _statusBar;
            set
            {
                _statusBar = value;
                OnPropertyChanged();
            }
        }

        private ICommand _newFileCommand;
        public ICommand NewFileCommand => _newFileCommand ??= new NewFileCommand(this, _messageDialog, _saveFileDialog, _docInfoService, _textFileWriter);

        private ICommand _openFileCommand;
        public ICommand OpenFileCommand => _openFileCommand ??= new OpenFileCommand(this, _messageDialog, _saveFileDialog, _openFileDialog, _docInfoService, _textFileWriter, _textFileReader);

        private ICommand _saveFileCommand;
        public ICommand SaveFileCommand => _saveFileCommand ??= new SaveFileCommand(this, _saveFileDialog, _docInfoService, _textFileWriter);

        private ICommand _saveFileAsCommand;
        public ICommand SaveFileAsCommand => _saveFileAsCommand ??= new SaveFileAsCommand(this, _saveFileDialog, _docInfoService, _textFileWriter);

        private ICommand _applicationCloseCommand;
        public ICommand ApplicationCloseCommand => _applicationCloseCommand ??= new ApplicationCloseCommand(this, _messageDialog, _saveFileDialog, _docInfoService, _textFileWriter);


        private ICommand _findCommand;
        public ICommand FindCommand => _findCommand ??= new FindCommand(this, _findDialog);

        private ICommand _goToLineCommand;
        public ICommand GoToLineCommand => _goToLineCommand ??= new GoToLineCommand(this, _goToLineDialog);

        private ICommand _deleteTextCommand;
        public ICommand DeleteTextCommand => _deleteTextCommand ??= new DeleteTextCommand(this);

        private ICommand _putDateTimeTextCommand;
        public ICommand PutDateTimeTextCommand => _putDateTimeTextCommand ??= new PutDateTimeTextCommand(this);
        

        private ICommand _fontsCommand;
        public ICommand FontsCommand => _fontsCommand ??= new FontsCommand(this, _fontDialog);

        private ICommand _backgroundColorCommand;
        public ICommand BackgroundColorCommand => _backgroundColorCommand ??= new BackgroundColorCommand(this, _colorDialog);

        private ICommand _changeTextWrappingCommand;
        public ICommand ChangeTextWrappingCommand => _changeTextWrappingCommand ??= new ChangeTextWrappingCommand(this);


        private ICommand _changeStatusBarVisibilityCommand;
        public ICommand ChangeStatusBarVisibilityCommand => _changeStatusBarVisibilityCommand ??= new ChangeStatusBarVisibilityCommand(this);
    }
}
