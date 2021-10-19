using System.Collections.Generic;
using Application.Utilities.Guard;

namespace Application.Client.Dialogs.OpenFileDialog.Models
{
    public class OpenFileDialogOptions
    {
        private readonly IReadOnlyDictionary<string, IReadOnlyList<string>>? _fileFilters;
        public IReadOnlyDictionary<string, IReadOnlyList<string>> FileFilters
        {
            get
            {
                Guard.ThrowIfNullOrEmpty(_fileFilters, nameof(FileFilters));

                return _fileFilters!;
            }

            init => _fileFilters = value;
        }
    }
}
