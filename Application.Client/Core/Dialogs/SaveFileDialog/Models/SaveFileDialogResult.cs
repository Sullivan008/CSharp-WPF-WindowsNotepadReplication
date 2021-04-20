using System;
using System.IO;
using Application.Client.Core.Dialogs.SaveFileDialog.Enums;

namespace Application.Client.Core.Dialogs.SaveFileDialog.Models
{
    public class SaveFileDialogResult
    {
        private readonly SaveFileDialogResultType? _savedFileDialogResultType;
        public SaveFileDialogResultType SavedFileDialogResultType
        {
            get
            {
                if (!_savedFileDialogResultType.HasValue)
                {
                    throw new ArgumentNullException(nameof(_savedFileDialogResultType), @"The value cannot be null!");
                }

                return _savedFileDialogResultType.Value;
            }
            init => _savedFileDialogResultType = value;
        }

        private readonly string _savedFilePath;
        public string SavedFilePath
        {
            get => _savedFilePath;
            init
            {
                if (!_savedFileDialogResultType.HasValue)
                {
                    throw new InvalidOperationException($"Without the result type of the save file dialog, the {nameof(SavedFilePath)} property cannot be set!");
                }

                if (_savedFileDialogResultType.Value == SaveFileDialogResultType.Cancel && !string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException("It is not possible to set the saved file path when, the save file dialog result type is cancelled!");
                }

                _savedFilePath = value;
            }
        }

        public string SavedFileName => Path.GetFileName(_savedFilePath);

        public string SavedFileNameWithoutExtension => Path.GetFileNameWithoutExtension(_savedFilePath);
    }
}
