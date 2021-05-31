using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Application.Client.Core.Commands;
using Application.Client.Core.Dialogs.MessageDialog.Enums;
using Application.Client.Core.Dialogs.MessageDialog.Models;
using Application.Client.Core.Dialogs.OpenFileDialog.Enums;
using Application.Client.Core.Dialogs.OpenFileDialog.Models;
using Application.Client.Core.Dialogs.SaveFileDialog.Enums;
using Application.Client.Core.Dialogs.SaveFileDialog.Models;
using Application.Client.Windows.Main.Services.Enums;
using Application.Core.Services.FileReader.Models;
using Application.Core.Services.FileWriter.Models;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ICommand _openFileCommand;
        public ICommand OpenFileCommand => _openFileCommand ??= new RelayCommandAsync(OpenFileCommandExecute);

        private async Task OpenFileCommandExecute()
        {
            if (_notepadStorageService.HasDocumentModified)
            {
                MessageDialogResult messageDialogResult = await _messageDialog.ShowMessageDialogAsync(
                    new MessageDialogOptions { Title = "Notepad", Content = $"Do you want to save the {_notepadStorageService.UsedFileNameWithExtension} changes?", Button = MessageBoxButton.YesNoCancel });

                switch (messageDialogResult.MessageDialogResultType)
                {
                    case MessageDialogResultType.Yes:
                        {
                            if (_notepadStorageService.HasUsedFile)
                            {
                                await _textFileWriterService.WriteAsync(new WriteTextFileModel { FilePath = _notepadStorageService.UsedFilePath, Content = _content });
                            }
                            else
                            {
                                SaveFileDialogResult saveFileDialogResult = await _saveFileDialog.ShowDialogAsync(new SaveFileDialogOptions { FileFilters = GetSaveFileDialogFilters() });

                                if (saveFileDialogResult.SaveFileDialogResultType == SaveFileDialogResultType.Ok)
                                {
                                    await _textFileWriterService.WriteAsync(new WriteTextFileModel { FilePath = saveFileDialogResult.SavedFilePath, Content = _content });
                                    _notepadStorageService.SetUsedFilePath(saveFileDialogResult.SavedFilePath);
                                }
                                else if (saveFileDialogResult.SaveFileDialogResultType == SaveFileDialogResultType.Cancel)
                                {
                                    return;
                                }
                            }

                            _notepadStorageService.SetDocumentState(DocumentState.Unmodified);
                            WindowTitle = _notepadStorageService.UsedFileNameWithoutExtension;

                            break;
                        }
                    case MessageDialogResultType.Cancel:
                        {
                            return;
                        }
                }
            }

            OpenFileDialogResult openFileDialogResult = await _openFileDialog.ShowDialogAsync(new OpenFileDialogOptions { FileFilters = GetOpenFileDialogFilters() });

            if (openFileDialogResult.OpenFileDialogResultType == OpenFileDialogResultType.Ok)
            {
                Content = await _textFileReaderService.ReadAsync<string>(new ReadTextFileModel { FilePath = openFileDialogResult.FilePath });

                _notepadStorageService.SetUsedFilePath(openFileDialogResult.FilePath);
                _notepadStorageService.SetDocumentState(DocumentState.Unmodified);

                WindowTitle = _notepadStorageService.UsedFileNameWithoutExtension;
            }
        }
    }
}
