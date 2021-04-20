﻿using System.Threading.Tasks;
using System.Windows.Input;
using Application.Client.Core.Commands;
using Application.Client.Core.Dialogs.SaveFileDialog.Enums;
using Application.Client.Core.Dialogs.SaveFileDialog.Models;
using Application.Client.Core.Services.FileWriter.Models;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ICommand _saveIntoNewFileCommand;
        public ICommand SaveIntoNewFileCommand => _saveIntoNewFileCommand ??= new RelayCommandAsync(SaveIntoNewFileCommandExecute);

        private async Task SaveIntoNewFileCommandExecute()
        {
            SaveFileDialogResult saveFileDialogResult =
                await _saveFileDialogService.ShowDialogAsync(new SaveFileDialogOptions { FileFilters = GetSaveFileDialogFilters() });

            if (saveFileDialogResult.SaveFileDialogResultType == SaveFileDialogResultType.Ok)
            {
                await _textFileWriterService.WriteAsync(new WriteTextFileModel { FilePath = saveFileDialogResult.SavedFilePath, Content = _content });

                _notepadStorageService.SetUsedFilePath(saveFileDialogResult.SavedFilePath);

                WindowTitle = saveFileDialogResult.SavedFileNameWithoutExtension;
            }
        }
    }
}
