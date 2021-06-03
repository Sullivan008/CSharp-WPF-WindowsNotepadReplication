using System;
using System.Collections.Generic;
using Application.Client.Core.Extensions;

namespace Application.Client.Dialogs.StaticValues.Models
{
    public class FileFilterModel
    {
        private readonly string _filterName;
        public string FilterName
        {
            get => _filterName;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(FilterName), "The value cannot be null!");
                }

                _filterName = value;
            }
        }

        private readonly IReadOnlyList<string> _filters;
        public IReadOnlyList<string> Filters
        {
            get => _filters;
            init
            {
                if (value.IsNullOrEmpty())
                {
                    throw new ArgumentNullException(nameof(Filters), "The value cannot be null!");
                }

                _filters = value;
            }
        }
    }
}
