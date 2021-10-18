using System;
using System.Collections.Generic;
using Application.Utilities.Extensions;

namespace Application.Client.Dialogs.StaticValues.Models
{
    public class FileFilterModel
    {
        private readonly string? _filterName;
        public string FilterName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_filterName))
                {
                    throw new ArgumentNullException(nameof(FilterName), "The value cannot be null!");
                }

                return _filterName;
            }

            init => _filterName = value;
        }

        private readonly IReadOnlyList<string>? _filters;
        public IReadOnlyList<string> Filters
        {
            get
            {
                if (_filters.IsNullOrEmpty())
                {
                    throw new ArgumentNullException(nameof(Filters), "The value cannot be null!");
                }

                return _filters!;
            }

            init => _filters = value;
        }
    }
}
