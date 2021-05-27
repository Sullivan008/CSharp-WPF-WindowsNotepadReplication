using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Client.Core.Dialogs.SaveFileDialog.Enums;
using Application.Client.Core.Dialogs.SaveFileDialog.Exceptions;
using Application.Client.Core.Dialogs.SaveFileDialog.Interfaces;
using Application.Client.Core.Dialogs.SaveFileDialog.Models;

namespace Application.Client.Core.Dialogs.SaveFileDialog
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
                    return new SaveFileDialogResult
                    {
                        SaveFileDialogResultType = SaveFileDialogResultType.Ok,
                        SavedFilePath = saveFileDialog.FileName
                    };
                case false:
                    return new SaveFileDialogResult
                    {
                        SaveFileDialogResultType = SaveFileDialogResultType.Cancel
                    };
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
    }
}
