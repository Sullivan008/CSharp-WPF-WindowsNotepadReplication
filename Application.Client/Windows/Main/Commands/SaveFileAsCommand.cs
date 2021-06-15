using System.Threading.Tasks;
using System.Windows.Input;
using Application.Client.Dialogs.SaveFileDialog.Enums;
using Application.Client.Dialogs.SaveFileDialog.Models;
using Application.Client.Infrastructure.Commands;
using Application.Utilities.FileWriter.Models;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ICommand _saveFileAsCommand;
        public ICommand SaveFileAsCommand => _saveFileAsCommand ??= new RelayCommandAsync(SaveFileAsCommandExecute);

        private async Task SaveFileAsCommandExecute()
        {
            SaveFileDialogResult saveFileDialogResult =
                await _saveFileDialog.ShowDialogAsync(new SaveFileDialogOptions { FileFilters = GetSaveFileDialogFilters() });

            if (saveFileDialogResult.SaveFileDialogResultType == SaveFileDialogResultType.Ok)
            {
                await _textFileWriter.WriteAsync(new WriteTextFileModel { FilePath = saveFileDialogResult.SavedFilePath, Content = _content });

                _docInfoService.SetFilePath(saveFileDialogResult.SavedFilePath);
                _docInfoService.SetUnmodifiedDocumentState();

                WindowTitle = _docInfoService.UsedFileNameWithoutExtension;
            }
        }
    }
}
