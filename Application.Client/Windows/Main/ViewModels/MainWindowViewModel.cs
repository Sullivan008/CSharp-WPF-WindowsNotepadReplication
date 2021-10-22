using System.Windows.Input;
using System.Windows.Threading;
using Application.Client.Common.ViewModels;
using Application.Client.Dialogs.ColorDialog.Interfaces;
using Application.Client.Dialogs.FindDialog.Interfaces;
using Application.Client.Dialogs.FontDialog.Interfaces;
using Application.Client.Dialogs.GoToLineDialog.Interfaces;
using Application.Client.Dialogs.MessageDialog.Interfaces;
using Application.Client.Dialogs.OpenFileDialog.Interfaces;
using Application.Client.Dialogs.ReplaceDialog.Interfaces;
using Application.Client.Dialogs.SaveFileDialog.Interfaces;
using Application.Client.Messenger.GenericMessages.DialogMessages;
using Application.Client.Messenger.GenericMessages.InputTextBoxMessages;
using Application.Client.Services.DocInfo.Interfaces;
using Application.Client.Services.FindNextAndReplaceConditions.Interfaces;
using Application.Client.Windows.Main.Commands.EditMenu;
using Application.Client.Windows.Main.Commands.FileMenu;
using Application.Client.Windows.Main.Commands.FormatMenu;
using Application.Client.Windows.Main.Commands.Shared;
using Application.Client.Windows.Main.Commands.ViewMenu;
using Application.Client.Windows.Main.ViewModels.InputTextBox;
using Application.Client.Windows.Main.ViewModels.Settings;
using Application.Client.Windows.Main.ViewModels.StatusBar;
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

        private readonly IReplaceDialog _replaceDialog;

        private readonly IOpenFileDialog _openFileDialog;

        private readonly ISaveFileDialog _saveFileDialog;

        private readonly IGoToLineDialog _goToLineDialog;

        private readonly ITextFileWriter _textFileWriter;

        private readonly ITextFileReader _textFileReader;

        private readonly IDocInfoService _docInfoService;
        
        private readonly IFindNextAndReplaceConditionsService _findNextSearchConditionsService;

        public MainWindowViewModel(WindowSettingsViewModel windowSettingsViewModel, InputTextBoxViewModel inputTextBoxViewModel, StatusBarViewModel statusBarViewModel, IFontDialog fontDialog,
            IFindDialog findDialog, IColorDialog colorDialog, IMessageDialog messageDialog, IReplaceDialog replaceDialog, IOpenFileDialog openFileDialog, ISaveFileDialog saveFileDialog,
            IGoToLineDialog goToLineDialog, ITextFileWriter textFileWriter, ITextFileReader textFileReader, IDocInfoService docInfoService, IFindNextAndReplaceConditionsService findNextSearchConditionsService)
        {
            _fontDialog = fontDialog;
            _findDialog = findDialog;
            _colorDialog = colorDialog;
            _messageDialog = messageDialog;
            _replaceDialog = replaceDialog;
            _openFileDialog = openFileDialog;
            _saveFileDialog = saveFileDialog;
            _goToLineDialog = goToLineDialog;
            _textFileWriter = textFileWriter;
            _textFileReader = textFileReader;
            _docInfoService = docInfoService;
            _findNextSearchConditionsService = findNextSearchConditionsService;

            StatusBarViewModel = statusBarViewModel;
            InputTextBoxViewModel = inputTextBoxViewModel;
            WindowSettingsViewModel = windowSettingsViewModel;

            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<FindNextMessage>(this, _ =>
            {
                Dispatcher.CurrentDispatcher.Invoke(() =>
                {
                    if (FindNextCommand.CanExecute(default))
                    {
                        FindNextCommand.Execute(default);
                    }
                });
            });

            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<RefreshStatusBarMessage>(this, message =>
            {
                Dispatcher.CurrentDispatcher.Invoke(() => StatusBarViewModel.RefreshOutputData(((InputTextBoxViewModel)message.Sender).Content));
            });

            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ReplaceNextMessage>(this, _ =>
            {
                Dispatcher.CurrentDispatcher.Invoke(() =>
                {
                    if (ReplaceNextCommand.CanExecute(default))
                    {
                        ReplaceNextCommand.Execute(default);
                    }
                });
            });

            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ReplaceAllMessage>(this, _ =>
            {
                Dispatcher.CurrentDispatcher.Invoke(() =>
                {
                    if (ReplaceAllCommand.CanExecute(default))
                    {
                        ReplaceAllCommand.Execute(default);
                    }
                });
            });
        }

        private static WindowSettingsViewModel? _windowSettingsViewModel;
        public WindowSettingsViewModel WindowSettingsViewModel
        {
            get => _windowSettingsViewModel!;
            set
            {
                _windowSettingsViewModel = value;
                OnPropertyChanged();
            }
        }

        private static InputTextBoxViewModel? _inputTextBoxViewModel;
        public InputTextBoxViewModel InputTextBoxViewModel
        {
            get => _inputTextBoxViewModel!;
            set
            {
                _inputTextBoxViewModel = value;
                OnPropertyChanged();
            }
        }

        private StatusBarViewModel? _statusBarViewModel;
        public StatusBarViewModel StatusBarViewModel
        {
            get => _statusBarViewModel!;
            set
            {
                _statusBarViewModel = value;
                OnPropertyChanged();
            }
        }

        private ICommand? _newFileCommand;
        public ICommand NewFileCommand => _newFileCommand ??= new NewFileCommand(this, _messageDialog, _saveFileDialog, _docInfoService, _textFileWriter);

        private ICommand? _openFileCommand;
        public ICommand OpenFileCommand => _openFileCommand ??= new OpenFileCommand(this, _messageDialog, _saveFileDialog, _openFileDialog, _docInfoService, _textFileWriter, _textFileReader);

        private ICommand? _saveFileCommand;
        public ICommand SaveFileCommand => _saveFileCommand ??= new SaveFileCommand(this, _saveFileDialog, _docInfoService, _textFileWriter);

        private ICommand? _saveFileAsCommand;
        public ICommand SaveFileAsCommand => _saveFileAsCommand ??= new SaveFileAsCommand(this, _saveFileDialog, _docInfoService, _textFileWriter);

        private ICommand? _applicationCloseCommand;
        public ICommand ApplicationCloseCommand => _applicationCloseCommand ??= new ApplicationCloseCommand(this, _messageDialog, _saveFileDialog, _docInfoService, _textFileWriter);


        private ICommand? _findCommand;
        public ICommand FindCommand => _findCommand ??= new FindCommand(this, _findDialog);

        private ICommand? _replaceCommand;
        public ICommand ReplaceCommand => _replaceCommand ??= new ReplaceCommand(this, _replaceDialog);

        private ICommand ReplaceAllCommand => new ReplaceAllCommand(this, _findNextSearchConditionsService);

        private ICommand ReplaceNextCommand => new ReplaceNextCommand(this, _messageDialog, _findNextSearchConditionsService);

        private ICommand? _findNextCommand;
        public ICommand FindNextCommand => _findNextCommand ??= new FindNextCommand(this, _messageDialog, _findNextSearchConditionsService);
        
        private ICommand? _goToLineCommand;
        public ICommand GoToLineCommand => _goToLineCommand ??= new GoToLineCommand(this, _goToLineDialog);

        private ICommand? _deleteTextCommand;
        public ICommand DeleteTextCommand => _deleteTextCommand ??= new DeleteTextCommand(this);

        private ICommand? _putDateTimeTextCommand;
        public ICommand PutDateTimeTextCommand => _putDateTimeTextCommand ??= new PutDateTimeTextCommand(this);



        private ICommand? _fontsCommand;
        public ICommand FontsCommand => _fontsCommand ??= new FontsCommand(this, _fontDialog);

        private ICommand? _backgroundColorCommand;
        public ICommand BackgroundColorCommand => _backgroundColorCommand ??= new BackgroundColorCommand(this, _colorDialog);

        private ICommand? _changeTextWrappingCommand;
        public ICommand ChangeTextWrappingCommand => _changeTextWrappingCommand ??= new ChangeTextWrappingCommand(this);


        private ICommand? _changeStatusBarVisibilityCommand;
        public ICommand ChangeStatusBarVisibilityCommand => _changeStatusBarVisibilityCommand ??= new ChangeStatusBarVisibilityCommand(this);
    }
}
