using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Client.Dialogs.SaveFileDialog.Enums;
using Application.Client.Dialogs.SaveFileDialog.Exceptions;
using Application.Client.Dialogs.SaveFileDialog.Interfaces;
using Application.Client.Dialogs.SaveFileDialog.Models;

namespace Application.Client.Dialogs.SaveFileDialog
{
    public class SaveFileDialog : ISaveFileDialog
    {
        public async Task<SaveFileDialogResult> ShowDialogAsync(SaveFileDialogOptions options)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new()
            {
                Filter = await ConvertFileFiltersToFileFilterFormat(options.FileFilters)
            };

            switch (saveFileDialog.ShowDialog())
            {
                case true:
                    return OnTrueResult(saveFileDialog);
                case false:
                    return OnFalseResult();
                default:
                    throw new SaveFileDialogUnknownResultTypeException("An unknown error occurred while reading the result of the dialog box!");
            }
        }

        private static Task<string> ConvertFileFiltersToFileFilterFormat(IReadOnlyDictionary<string, IReadOnlyList<string>> fileFilters)
        {
            const string FILE_FILTER_SEPARATOR = "|";
            
            string result = string.Join(FILE_FILTER_SEPARATOR, fileFilters.Select(x => ConvertFileFilterRowToFileFilterFormat(x.Key, x.Value)));

            return Task.FromResult(result);
        }

        private static string ConvertFileFilterRowToFileFilterFormat(string filterName, IReadOnlyList<string> filters)
        {
            const string SEPARATOR_IN_PARENTHESIS = ",";
            const string SEPARATOR_IN_FILTER_SETTINGS = ";";

            return $"{filterName} ({string.Join(SEPARATOR_IN_PARENTHESIS, filters)})|{string.Join(SEPARATOR_IN_FILTER_SETTINGS, filters)}";
        }

        private static SaveFileDialogResult OnTrueResult(Microsoft.Win32.SaveFileDialog saveFileDialog)
        {
            return new SaveFileDialogResult
            {
                SaveFileDialogResultType = SaveFileDialogResultType.Ok,
                SavedFilePath = saveFileDialog.FileName
            };
        }

        private static SaveFileDialogResult OnFalseResult()
        {
            return new SaveFileDialogResult
            {
                SaveFileDialogResultType = SaveFileDialogResultType.Cancel
            };
        }
    }
}
