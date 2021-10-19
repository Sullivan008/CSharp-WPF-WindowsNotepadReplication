using System.Collections.Generic;
using Application.Utilities.Guard;

namespace Application.Client.Dialogs.StaticValues.Models
{
    public class FileFilterModel
    {
        private readonly string? _filterName;
        public string FilterName
        {
            get
            {
                Guard.ThrowIfNullOrWhitespace(_filterName, nameof(FilterName));

                return _filterName!;
            }

            init => _filterName = value;
        }

        private readonly IReadOnlyList<string>? _filters;
        public IReadOnlyList<string> Filters
        {
            get
            {
                Guard.ThrowIfNullOrEmpty(_filters, nameof(Filters));
                
                return _filters!;
            }

            init => _filters = value;
        }
    }
}
