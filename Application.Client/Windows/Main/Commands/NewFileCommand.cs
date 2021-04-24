﻿using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Application.Client.Core.Commands;
using Application.Client.Core.Dialogs.MessageDialog.Enums;
using Application.Client.Core.Dialogs.MessageDialog.Models;
using Application.Client.Core.Dialogs.SaveFileDialog.Enums;
using Application.Client.Core.Dialogs.SaveFileDialog.Models;
using Application.Client.Core.Services.FileWriter.Models;
using Application.Client.Windows.Main.Services.Enums;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ICommand _newFileCommand;
        public ICommand NewFileCommand => _newFileCommand ??= new RelayCommandAsync(NewFileCommandExecute);

        private async Task NewFileCommandExecute()
        {
            if (_notepadStorageService.HasDocumentModified)
            {
                MessageDialogResult messageDialogResult = await _messageDialogService.ShowDialogAsync(
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
                                SaveFileDialogResult saveFileDialogResult = await _saveFileDialogService.ShowDialogAsync(new SaveFileDialogOptions { FileFilters = GetSaveFileDialogFilters() });

                                if (saveFileDialogResult.SaveFileDialogResultType == SaveFileDialogResultType.Ok)
                                {
                                    await _textFileWriterService.WriteAsync(new WriteTextFileModel { FilePath = saveFileDialogResult.SavedFilePath, Content = _content });
                                }
                                else if (saveFileDialogResult.SaveFileDialogResultType == SaveFileDialogResultType.Cancel)
                                {
                                    return;
                                }
                            }

                            Content = string.Empty;

                            _notepadStorageService.SetDefaultFilePath();
                            _notepadStorageService.SetDocumentState(DocumentState.Unmodified);

                            WindowTitle = _notepadStorageService.UsedFileNameWithoutExtension;

                            break;
                        }
                    case MessageDialogResultType.No:
                        {
                            Content = string.Empty;

                            _notepadStorageService.SetDefaultFilePath();
                            _notepadStorageService.SetDocumentState(DocumentState.Unmodified);

                            WindowTitle = _notepadStorageService.UsedFileNameWithoutExtension;

                            break;
                        }
                }
            }
            else
            {
                Content = string.Empty;

                _notepadStorageService.SetDefaultFilePath();
                _notepadStorageService.SetDocumentState(DocumentState.Unmodified);

                WindowTitle = _notepadStorageService.UsedFileNameWithoutExtension;
            }
        }
    }
}
