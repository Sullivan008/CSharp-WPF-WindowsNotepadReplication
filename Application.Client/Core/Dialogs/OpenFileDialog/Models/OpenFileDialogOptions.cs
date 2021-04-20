﻿using System;
using System.Collections.Generic;
using Application.Core.Extensions;

namespace Application.Client.Core.Dialogs.OpenFileDialog.Models
{
    public class OpenFileDialogOptions
    {
        private readonly IReadOnlyDictionary<string, IReadOnlyList<string>> _fileFilters;
        public IReadOnlyDictionary<string, IReadOnlyList<string>> FileFilters
        {
            get => _fileFilters;
            init
            {
                if (value.IsNullOrEmpty())
                {
                    throw new ArgumentNullException(nameof(FileFilters), @"The value cannot be null!");
                }

                _fileFilters = value;
            }
        }
    }
}
