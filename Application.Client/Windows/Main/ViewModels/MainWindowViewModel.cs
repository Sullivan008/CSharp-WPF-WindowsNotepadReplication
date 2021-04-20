using Application.Client.Core.Dialogs.MessageDialog.Interfaces;
using Application.Client.Core.Dialogs.OpenFileDialog.Interfaces;
using Application.Client.Core.Dialogs.SaveFileDialog.Interfaces;
using Application.Client.Core.Services.FileReader.Interfaces;
using Application.Client.Core.Services.FileWriter.Interfaces;
using Application.Client.Core.ViewModels;
using Application.Client.Windows.Main.ViewModels.Interfaces;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private readonly IMessageDialogService _messageDialogService;

        private readonly IOpenFileDialogService _openFileDialogService;

        private readonly ISaveFileDialogService _saveFileDialogService;

        private readonly ITextFileWriterService _textFileWriterService;

        private readonly ITextFileReaderService _textFileReaderService;
        
        public MainWindowViewModel(IMessageDialogService messageDialogService, IOpenFileDialogService openFileDialogService, ISaveFileDialogService saveFileDialogService,
            ITextFileWriterService textFileWriterService, ITextFileReaderService textFileReaderService)
        {
            _messageDialogService = messageDialogService;
            _openFileDialogService = openFileDialogService;
            _saveFileDialogService = saveFileDialogService;
            _textFileWriterService = textFileWriterService;
            _textFileReaderService = textFileReaderService;
        }
    }
}
