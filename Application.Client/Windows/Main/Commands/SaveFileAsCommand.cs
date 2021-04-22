﻿using System.Threading.Tasks;
using System.Windows.Input;
using Application.Client.Core.Commands;
using Application.Client.Core.Dialogs.SaveFileDialog.Enums;
using Application.Client.Core.Dialogs.SaveFileDialog.Models;
using Application.Client.Core.Services.FileWriter.Models;
using Application.Client.Windows.Main.Services.Enums;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ICommand _saveFileAsCommand;
        public ICommand SaveFileAsCommand => _saveFileAsCommand ??= new RelayCommandAsync(SaveFileAsCommandExecute);

        private async Task SaveFileAsCommandExecute()
        {
            SaveFileDialogResult saveFileDialogResult =
                await _saveFileDialogService.ShowDialogAsync(new SaveFileDialogOptions { FileFilters = GetSaveFileDialogFilters() });

            if (saveFileDialogResult.SaveFileDialogResultType == SaveFileDialogResultType.Ok)
            {
                await _textFileWriterService.WriteAsync(new WriteTextFileModel { FilePath = saveFileDialogResult.SavedFilePath, Content = _content });

                _notepadStorageService.SetUsedFilePath(saveFileDialogResult.SavedFilePath);
                _notepadStorageService.SetDocumentState(DocumentState.Unmodified);

                WindowTitle = _notepadStorageService.UsedFileNameWithoutExtension;
            }
        }
    }
}
