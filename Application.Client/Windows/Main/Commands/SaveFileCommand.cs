using System.Threading.Tasks;
using System.Windows.Input;
using Application.Client.Core.Commands;
using Application.Client.Dialogs.SaveFileDialog.Enums;
using Application.Client.Dialogs.SaveFileDialog.Models;
using Application.Client.Windows.Main.Services.Enums;
using Application.Utilities.FileWriter.Models;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ICommand _saveFileCommand;
        public ICommand SaveFileCommand => _saveFileCommand ??= new RelayCommandAsync(SaveFileCommandExecute);

        private async Task SaveFileCommandExecute()
        {
            if (_notepadStorageService.HasUsedFile)
            {
                await _textFileWriter.WriteAsync(new WriteTextFileModel { FilePath = _notepadStorageService.UsedFilePath, Content = _content });

                _notepadStorageService.SetDocumentState(DocumentState.Unmodified);

                WindowTitle = _notepadStorageService.UsedFileNameWithoutExtension;
            }
            else
            {
                SaveFileDialogResult saveFileDialogResult =
                    await _saveFileDialog.ShowDialogAsync(new SaveFileDialogOptions { FileFilters = GetSaveFileDialogFilters() });

                if (saveFileDialogResult.SaveFileDialogResultType == SaveFileDialogResultType.Ok)
                {
                    await _textFileWriter.WriteAsync(new WriteTextFileModel { FilePath = saveFileDialogResult.SavedFilePath, Content = _content });

                    _notepadStorageService.SetUsedFilePath(saveFileDialogResult.SavedFilePath);
                    _notepadStorageService.SetDocumentState(DocumentState.Unmodified);

                    WindowTitle = _notepadStorageService.UsedFileNameWithoutExtension;
                }
            }
        }
    }
}
