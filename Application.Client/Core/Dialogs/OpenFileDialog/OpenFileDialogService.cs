﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Client.Core.Dialogs.OpenFileDialog.Enums;
using Application.Client.Core.Dialogs.OpenFileDialog.Exceptions;
using Application.Client.Core.Dialogs.OpenFileDialog.Interfaces;
using Application.Client.Core.Dialogs.OpenFileDialog.Models;

namespace Application.Client.Core.Dialogs.OpenFileDialog
{
    public class OpenFileDialogService : IOpenFileDialogService
    {
        public async Task<OpenFileDialogResult> ShowDialogAsync(OpenFileDialogOptions options)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new()
            {
                Filter = await ConvertFileFiltersToFileFilterFormat(options.FileFilters)
            };

            switch (openFileDialog.ShowDialog())
            {
                case true:
                    return new OpenFileDialogResult
                    {
                        OpenFileDialogResultType = OpenFileDialogResultType.Ok,
                        FilePath = openFileDialog.FileName
                    };
                case false:
                    return new OpenFileDialogResult
                    {
                        OpenFileDialogResultType = OpenFileDialogResultType.Cancel
                    };
                default:
                    throw new OpenFileDialogUnknownResultType("An unknown error occurred while reading the result of the dialog box!");
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
