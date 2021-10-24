using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Application.Client.Common.Commands;
using Application.Client.Dialogs.MessageDialog.Enums;
using Application.Client.Dialogs.MessageDialog.Interfaces;
using Application.Client.Dialogs.MessageDialog.Models;
using Application.Client.Dialogs.OpenFileDialog.Enums;
using Application.Client.Dialogs.OpenFileDialog.Interfaces;
using Application.Client.Dialogs.OpenFileDialog.Models;
using Application.Client.Dialogs.SaveFileDialog.Enums;
using Application.Client.Dialogs.SaveFileDialog.Interfaces;
using Application.Client.Dialogs.SaveFileDialog.Models;
using Application.Client.Dialogs.StaticValues;
using Application.Client.Dialogs.StaticValues.Enums;
using Application.Client.Dialogs.StaticValues.Models;
using Application.Client.Services.DocInfo.Interfaces;
using Application.Client.Windows.Main.ViewModels;
using Application.Utilities.FileReader.Interfaces;
using Application.Utilities.FileReader.Models;
using Application.Utilities.FileWriter.Interfaces;
using Application.Utilities.FileWriter.Models;

namespace Application.Client.Windows.Main.Commands.FileMenu
{
    internal class OpenFileCommand : AsyncCommandBase<MainWindowViewModel>
    {
        private readonly IMessageDialog _messageDialog;

        private readonly ISaveFileDialog _saveFileDialog;

        private readonly IOpenFileDialog _openFileDialog;

        private readonly IDocInfoService _docInfoService;

        private readonly ITextFileWriter _textFileWriter;

        private readonly ITextFileReader _textFileReader;

        public OpenFileCommand(MainWindowViewModel callerViewModel, IMessageDialog messageDialog, ISaveFileDialog saveFileDialog, IOpenFileDialog openFileDialog,
            IDocInfoService docInfoService, ITextFileWriter textFileWriter, ITextFileReader textFileReader) : base(callerViewModel)
        {
            _messageDialog = messageDialog;
            _saveFileDialog = saveFileDialog;
            _openFileDialog = openFileDialog;
            _docInfoService = docInfoService;
            _textFileWriter = textFileWriter;
            _textFileReader = textFileReader;
        }

        public override async Task ExecuteAsync()
        {
            if (_docInfoService.IsModifiedDocument)
            {
                MessageDialogResult messageDialogResult = await _messageDialog.ShowDialogAsync(
                    new MessageDialogOptions { Title = "Notepad", Content = $"Do you want to save the {_docInfoService.UsedFileNameWithExtension} changes?", Button = MessageBoxButton.YesNoCancel });

                switch (messageDialogResult.MessageDialogResultType)
                {
                    case MessageDialogResultType.Yes:
                        {
                            if (_docInfoService.IsOpenedDocument)
                            {
                                await _textFileWriter.WriteAsync(new WriteTextFileModel { FilePath = _docInfoService.UsedFilePath, Content = CallerViewModel.InputTextBoxViewModel.Content });
                            }
                            else
                            {
                                SaveFileDialogResult saveFileDialogResult = await _saveFileDialog.ShowDialogAsync(new SaveFileDialogOptions { FileFilters = GetSaveFileDialogFilters() });

                                if (saveFileDialogResult.SaveFileDialogResultType == SaveFileDialogResultType.Ok)
                                {
                                    await _textFileWriter.WriteAsync(new WriteTextFileModel { FilePath = saveFileDialogResult.SavedFilePath, Content = CallerViewModel.InputTextBoxViewModel.Content });
                                    _docInfoService.SetFilePath(saveFileDialogResult.SavedFilePath);
                                }
                                else if (saveFileDialogResult.SaveFileDialogResultType == SaveFileDialogResultType.Cancel)
                                {
                                    return;
                                }
                            }

                            _docInfoService.SetUnmodifiedDocumentState();
                            CallerViewModel.WindowSettingsViewModel.Title = _docInfoService.UsedFileNameWithoutExtension;

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
                CallerViewModel.InputTextBoxViewModel.Content = await _textFileReader.ReadAsync<string>(new ReadTextFileModel { FilePath = openFileDialogResult.FilePath });

                _docInfoService.SetFilePath(openFileDialogResult.FilePath);
                _docInfoService.SetUnmodifiedDocumentState();

                CallerViewModel.WindowSettingsViewModel.Title = _docInfoService.UsedFileNameWithoutExtension;
            }
        }

        private static IReadOnlyDictionary<string, IReadOnlyList<string>> GetSaveFileDialogFilters()
        {
            IReadOnlyList<FileFilterModel> fileFilters =
                FileFilters.GetFileFiltersByFilterTypes(new[] { FileFilterType.Text });

            return fileFilters.ToDictionary(x => x.FilterName, y => y.Filters);
        }

        private static IReadOnlyDictionary<string, IReadOnlyList<string>> GetOpenFileDialogFilters()
        {
            IReadOnlyList<FileFilterModel> fileFilters = FileFilters.GetFileFiltersByFilterTypes(new[] { FileFilterType.Text });

            return fileFilters.ToDictionary(x => x.FilterName, y => y.Filters);
        }
    }
}
