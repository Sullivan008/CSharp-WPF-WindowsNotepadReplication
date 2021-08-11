using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Application.Client.Dialogs.StaticValues.Enums;
using Application.Client.Dialogs.StaticValues.Models;

namespace Application.Client.Dialogs.StaticValues
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

        public static IReadOnlyList<FileFilterModel> GetFileFiltersByFilterTypes(IEnumerable<FileFilterType> types)
        {
            List<FileFilterModel> result = new();

            foreach (FileFilterType type in types)
            {
                if (!FileFilterTypes.TryGetValue(type, out FileFilterModel fileFilter))
                {
                    throw new ArgumentNullException(nameof(result), $"The following File Filter Type does not exist with this type. {nameof(type).ToUpper()}: {type}");
                }

                result.Add(fileFilter);
            }

            return result;
        }
    }
}
