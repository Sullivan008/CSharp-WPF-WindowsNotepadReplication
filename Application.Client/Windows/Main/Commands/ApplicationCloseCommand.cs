﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Application.Client.Dialogs.MessageDialog.Enums;
using Application.Client.Dialogs.MessageDialog.Models;
using Application.Client.Dialogs.SaveFileDialog.Enums;
using Application.Client.Dialogs.SaveFileDialog.Models;
using Application.Client.Infrastructure.Commands;
using Application.Utilities.FileWriter.Models;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ICommand _applicationCloseCommand;
        public ICommand ApplicationCloseCommand => _applicationCloseCommand ??= new RelayCommandAsync<CancelEventArgs>(ApplicationCloseCommandExecute);

        private async void ApplicationCloseCommandExecute(CancelEventArgs eventArgs)
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
                                await _textFileWriter.WriteAsync(new WriteTextFileModel { FilePath = _docInfoService.UsedFilePath, Content = InputTextBoxViewModel.Content });
                            }
                            else
                            {
                                SaveFileDialogResult saveFileDialogResult = await _saveFileDialog.ShowDialogAsync(new SaveFileDialogOptions { FileFilters = GetSaveFileDialogFilters() });

                                if (saveFileDialogResult.SaveFileDialogResultType == SaveFileDialogResultType.Ok)
                                {
                                    await _textFileWriter.WriteAsync(new WriteTextFileModel { FilePath = saveFileDialogResult.SavedFilePath, Content = InputTextBoxViewModel.Content });
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
