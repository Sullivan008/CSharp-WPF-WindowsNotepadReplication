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
using Application.Client.Core.Services.FileReader.Models;
using Application.Client.Core.Services.FileWriter.Models;
using Application.Client.Windows.Main.Services.Enums;

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
                MessageDialogResult messageDialogResult = await _messageDialogService.ShowDialogAsync(
                    new MessageDialogOptions { Title = "Notepad", Content = $"Do you want save {_notepadStorageService.UsedFileNameWithExtension} changes?", Button = MessageBoxButton.YesNoCancel });

                switch (messageDialogResult.MessageDialogResultType)
                {
                    case MessageDialogResultType.Yes:
                        {
                            SaveFileDialogResult saveFileDialogResult = await _saveFileDialogService.ShowDialogAsync(new SaveFileDialogOptions { FileFilters = GetSaveFileDialogFilters() });

                            if (saveFileDialogResult.SaveFileDialogResultType == SaveFileDialogResultType.Ok)
                            {
                                await _textFileWriterService.WriteAsync(new WriteTextFileModel { FilePath = saveFileDialogResult.SavedFilePath, Content = _content });
                                _notepadStorageService.SetUsedFilePath(saveFileDialogResult.SavedFilePath);

                                OpenFileDialogResult openFileDialogResult = await _openFileDialogService.ShowDialogAsync(new OpenFileDialogOptions { FileFilters = GetOpenFileDialogFilters() });

                                if (openFileDialogResult.OpenFileDialogResultType == OpenFileDialogResultType.Ok)
                                {
                                    Content = await _textFileReaderService.ReadAsync<string>(new ReadTextFileModel { FilePath = openFileDialogResult.FilePath });
                                    _notepadStorageService.SetUsedFilePath(openFileDialogResult.OpenedFileName);
                                }

                                _notepadStorageService.SetDocumentState(DocumentState.Unmodified);
                                WindowTitle = _notepadStorageService.UsedFileNameWithoutExtension;
                            }

                            break;
                        }
                    case MessageDialogResultType.No:
                        {
                            OpenFileDialogResult openFileDialogResult = await _openFileDialogService.ShowDialogAsync(new OpenFileDialogOptions { FileFilters = GetOpenFileDialogFilters() });

                            if (openFileDialogResult.OpenFileDialogResultType == OpenFileDialogResultType.Ok)
                            {
                                Content = await _textFileReaderService.ReadAsync<string>(new ReadTextFileModel { FilePath = openFileDialogResult.FilePath });

                                _notepadStorageService.SetUsedFilePath(openFileDialogResult.FilePath);
                                _notepadStorageService.SetDocumentState(DocumentState.Unmodified);

                                WindowTitle = _notepadStorageService.UsedFileNameWithoutExtension;
                            }

                            break;
                        }
                }
            }
            else
            {
                OpenFileDialogResult openFileDialogResult = await _openFileDialogService.ShowDialogAsync(new OpenFileDialogOptions { FileFilters = GetOpenFileDialogFilters() });

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
}
