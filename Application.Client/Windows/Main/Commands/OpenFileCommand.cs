using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Application.Client.Dialogs.MessageDialog.Enums;
using Application.Client.Dialogs.MessageDialog.Models;
using Application.Client.Dialogs.OpenFileDialog.Enums;
using Application.Client.Dialogs.OpenFileDialog.Models;
using Application.Client.Dialogs.SaveFileDialog.Enums;
using Application.Client.Dialogs.SaveFileDialog.Models;
using Application.Client.Infrastructure.Commands;
using Application.Utilities.FileReader.Models;
using Application.Utilities.FileWriter.Models;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ICommand _openFileCommand;
        public ICommand OpenFileCommand => _openFileCommand ??= new RelayCommandAsync(OpenFileCommandExecute);

        private async Task OpenFileCommandExecute()
        {
            if (_docInfoService.IsModifiedDocument)
            {
                MessageDialogResult messageDialogResult = await _messageDialog.ShowMessageDialogAsync(
                    new MessageDialogOptions { Title = "Notepad", Content = $"Do you want to save the {_docInfoService.UsedFileNameWithExtension} changes?", Button = MessageBoxButton.YesNoCancel });

                switch (messageDialogResult.MessageDialogResultType)
                {
                    case MessageDialogResultType.Yes:
                        {
                            if (_docInfoService.IsOpenedDocument)
                            {
                                await _textFileWriter.WriteAsync(new WriteTextFileModel { FilePath = _docInfoService.UsedFilePath, Content = InputTextBox.Content });
                            }
                            else
                            {
                                SaveFileDialogResult saveFileDialogResult = await _saveFileDialog.ShowDialogAsync(new SaveFileDialogOptions { FileFilters = GetSaveFileDialogFilters() });

                                if (saveFileDialogResult.SaveFileDialogResultType == SaveFileDialogResultType.Ok)
                                {
                                    await _textFileWriter.WriteAsync(new WriteTextFileModel { FilePath = saveFileDialogResult.SavedFilePath, Content = InputTextBox.Content });
                                    _docInfoService.SetFilePath(saveFileDialogResult.SavedFilePath);
                                }
                                else if (saveFileDialogResult.SaveFileDialogResultType == SaveFileDialogResultType.Cancel)
                                {
                                    return;
                                }
                            }

                            _docInfoService.SetUnmodifiedDocumentState();
                            WindowTitle = _docInfoService.UsedFileNameWithoutExtension;

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
                InputTextBox.Content = await _textFileReader.ReadAsync<string>(new ReadTextFileModel { FilePath = openFileDialogResult.FilePath });

                _docInfoService.SetFilePath(openFileDialogResult.FilePath);
                _docInfoService.SetUnmodifiedDocumentState();

                WindowTitle = _docInfoService.UsedFileNameWithoutExtension;
            }
        }
    }
}
