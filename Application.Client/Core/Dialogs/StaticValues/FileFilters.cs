using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Application.Client.Core.Dialogs.StaticValues.Enums;
using Application.Client.Core.Dialogs.StaticValues.Models;

namespace Application.Client.Core.Dialogs.StaticValues
{
    public static class FileFilters
    {
        private static readonly IReadOnlyDictionary<FileFilterType, FileFilterModel> FileFilterTypes;

        static FileFilters()
        {
            FileFilterTypes = new ReadOnlyDictionary<FileFilterType, FileFilterModel>(new Dictionary<FileFilterType, FileFilterModel>
            {
                { FileFilterType.AllFiles, new FileFilterModel { FilterName = "All files",  Filters = new [] { "*.*" } } },
                { FileFilterType.Text, new FileFilterModel {FilterName = "Text files", Filters = new [] {"*.txt"} } }
            });
        }

        public static IReadOnlyList<FileFilterModel> GetFileFiltersByFilterTypes(IEnumerable<FileFilterType> keys)
        {
            List<FileFilterModel> result = new();

            foreach (FileFilterType key in keys)
            {
                FileFilterTypes.TryGetValue(key, out FileFilterModel fileFilter);

                if (result == null)
                {
                    throw new ArgumentNullException(nameof(result), $@"The following File Filter Type does not exist with this key. {nameof(key).ToUpper()}: {key}");
                }

                result.Add(fileFilter);
            }

            return result;
        }
    }
}
