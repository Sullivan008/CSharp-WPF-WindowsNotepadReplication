using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Application.Client.Core.Commands;
using Application.Client.Core.Dialogs.MessageDialog.Enums;
using Application.Client.Core.Dialogs.MessageDialog.Models;
using Application.Client.Core.Dialogs.SaveFileDialog.Enums;
using Application.Client.Core.Dialogs.SaveFileDialog.Models;
using Application.Client.Core.Services.FileWriter.Models;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ICommand _applicationCloseCommand;
        public ICommand ApplicationCloseCommand => _applicationCloseCommand ??= new RelayCommandAsync<CancelEventArgs>(ApplicationCloseCommandExecute);

        private async void ApplicationCloseCommandExecute(CancelEventArgs eventArgs)
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
                                }
                                else if (saveFileDialogResult.SaveFileDialogResultType == SaveFileDialogResultType.Cancel)
                                {
                                    eventArgs.Cancel = true;
                                    return;
                                }
                            }

                            break;
                        }
                    case MessageDialogResultType.Cancel:
                        {
                            eventArgs.Cancel = true;
                            return;
                        }
                }
            }

            System.Windows.Application.Current.Shutdown();
        }
    }
}
