using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Client.Dialogs.SaveFileDialog.Enums;
using Application.Client.Dialogs.SaveFileDialog.Interfaces;
using Application.Client.Dialogs.SaveFileDialog.Models;
using Application.Client.Dialogs.StaticValues;
using Application.Client.Dialogs.StaticValues.Enums;
using Application.Client.Dialogs.StaticValues.Models;
using Application.Client.Infrastructure.Commands;
using Application.Client.Services.Interfaces;
using Application.Client.Windows.Main.ViewModels;
using Application.Utilities.FileWriter.Interfaces;
using Application.Utilities.FileWriter.Models;

namespace Application.Client.Windows.Main.Commands.FileMenu
{
    public class SaveFileCommand : AsyncCommandBase<MainWindowViewModel>
    {
        private readonly ISaveFileDialog _saveFileDialog;

        private readonly IDocInfoService _docInfoService;

        private readonly ITextFileWriter _textFileWriter;
        
        public SaveFileCommand(MainWindowViewModel callerViewModel, ISaveFileDialog saveFileDialog, IDocInfoService docInfoService, ITextFileWriter textFileWriter) : base(callerViewModel)
        {
            _saveFileDialog = saveFileDialog;
            _docInfoService = docInfoService;
            _textFileWriter = textFileWriter;
        }

        public override async Task ExecuteAsync()
        {
            if (_docInfoService.IsOpenedDocument)
            {
                await _textFileWriter.WriteAsync(new WriteTextFileModel { FilePath = _docInfoService.UsedFilePath, Content = CallerViewModel.InputTextBox.Content });

                _docInfoService.SetUnmodifiedDocumentState();

                CallerViewModel.WindowTitle = _docInfoService.UsedFileNameWithoutExtension;
            }
            else
            {
                SaveFileDialogResult saveFileDialogResult =
                    await _saveFileDialog.ShowDialogAsync(new SaveFileDialogOptions { FileFilters = GetSaveFileDialogFilters() });

                if (saveFileDialogResult.SaveFileDialogResultType == SaveFileDialogResultType.Ok)
                {
                    await _textFileWriter.WriteAsync(new WriteTextFileModel { FilePath = saveFileDialogResult.SavedFilePath, Content = CallerViewModel.InputTextBox.Content });

                    _docInfoService.SetFilePath(saveFileDialogResult.SavedFilePath);
                    _docInfoService.SetUnmodifiedDocumentState();

                    CallerViewModel.WindowTitle = _docInfoService.UsedFileNameWithoutExtension;
                }
            }
        }

        private static IReadOnlyDictionary<string, IReadOnlyList<string>> GetSaveFileDialogFilters()
        {
            IReadOnlyList<FileFilterModel> fileFilters =
                FileFilters.GetFileFiltersByFilterTypes(new[] { FileFilterType.Text });

            return fileFilters.ToDictionary(x => x.FilterName, y => y.Filters);
        }
    }
}
