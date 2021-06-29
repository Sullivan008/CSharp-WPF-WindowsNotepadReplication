using System;
using System.Collections.Generic;
using Application.Utilities.Extensions;

namespace Application.Client.Dialogs.OpenFileDialog.Models
{
    public class OpenFileDialogOptions
    {
        private readonly IReadOnlyDictionary<string, IReadOnlyList<string>> _fileFilters;
        public IReadOnlyDictionary<string, IReadOnlyList<string>> FileFilters
        {
            get
            {
                if (_fileFilters.IsNullOrEmpty())
                {
                    throw new ArgumentNullException(nameof(FileFilters), "The value cannot be null!");
                }

                return _fileFilters;
            }

            init => _fileFilters = value;
        }
    }
}
