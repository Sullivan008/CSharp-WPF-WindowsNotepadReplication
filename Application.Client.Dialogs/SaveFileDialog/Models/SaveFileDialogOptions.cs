using System;
using System.Collections.Generic;
using Application.Utilities.Extensions;

namespace Application.Client.Dialogs.SaveFileDialog.Models
{
    public class SaveFileDialogOptions
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
