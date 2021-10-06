using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Client.Dialogs.OpenFileDialog.Enums;
using Application.Client.Dialogs.OpenFileDialog.Exceptions;
using Application.Client.Dialogs.OpenFileDialog.Interfaces;
using Application.Client.Dialogs.OpenFileDialog.Models;

namespace Application.Client.Dialogs.OpenFileDialog
{
    public class OpenFileDialog : IOpenFileDialog
    {
        public async Task<OpenFileDialogResult> ShowDialogAsync(OpenFileDialogOptions options)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new()
            {
                Filter = await ConvertFileFiltersToFileFilterFormat(options.FileFilters)
            };

            return openFileDialog.ShowDialog() switch
            {
                true => OnTrueResult(openFileDialog),
                false => OnFalseResult(),
                _ => throw new OpenFileDialogUnknownResultTypeException("An unknown error occurred while reading the result of the dialog box!")
            };
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

        private static OpenFileDialogResult OnTrueResult(Microsoft.Win32.OpenFileDialog openFileDialog)
        {
            return new OpenFileDialogResult
            {
                OpenFileDialogResultType = OpenFileDialogResultType.Ok,
                FilePath = openFileDialog.FileName
            };
        }

        private static OpenFileDialogResult OnFalseResult()
        {
            return new OpenFileDialogResult
            {
                OpenFileDialogResultType = OpenFileDialogResultType.Cancel
            };
        }
    }
}
