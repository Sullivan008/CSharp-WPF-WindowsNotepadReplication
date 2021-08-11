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
using Application.Client.Services.FindDialogSearchTerms.Interfaces;
using Application.Client.Services.Interfaces;
using Application.Client.Windows.Main.Commands.EditMenu;
using Application.Client.Windows.Main.Commands.FileMenu;
using Application.Client.Windows.Main.Commands.FormatMenu;
using Application.Client.Windows.Main.Commands.Shared;
using Application.Client.Windows.Main.Commands.ViewMenu;
using Application.Client.Windows.Main.ViewModels.Settings;
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

        private readonly IFindDialogSearchTermsService _findDialogSearchTermsService;

        public MainWindowViewModel(WindowSettingsViewModel windowSettings, InputTextBoxViewModel inputTextBox, StatusBarViewModel statusBar, IFontDialog fontDialog, IFindDialog findDialog,
            IColorDialog colorDialog, IMessageDialog messageDialog, IOpenFileDialog openFileDialog, ISaveFileDialog saveFileDialog, IGoToLineDialog goToLineDialog, ITextFileWriter textFileWriter,
            ITextFileReader textFileReader, IDocInfoService docInfoService, IFindDialogSearchTermsService findDialogSearchTermsService)
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
            _findDialogSearchTermsService = findDialogSearchTermsService;

            StatusBar = statusBar;
            InputTextBox = inputTextBox;
            WindowSettings = windowSettings;

            InputTextBox.OnRefreshStatusBarEvent += (sender, _) => { Dispatcher.CurrentDispatcher.Invoke(() => StatusBar.RefreshOutputData(((InputTextBoxViewModel)sender).Content)); };

            _findDialog.OnFindNextEvent += (_, _) =>
            {
                Dispatcher.CurrentDispatcher.Invoke(() =>
                {
                    if (FindNextCommand.CanExecute(default))
                    {
                        FindNextCommand.Execute(default);
                    }
                });
            };
        }

        private static WindowSettingsViewModel _windowSettings;
        public WindowSettingsViewModel WindowSettings
        {
            get => _windowSettings;
            set
            {
                _windowSettings = value;
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

        private ICommand _findNextCommand;
        public ICommand FindNextCommand => _findNextCommand ??= new Commands.EditMenu.FindNextCommand(this, _messageDialog, _findDialogSearchTermsService);

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
