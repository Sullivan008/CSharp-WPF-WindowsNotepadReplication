using System;
using System.IO;
using Application.Client.Dialogs.SaveFileDialog.Enums;
using Application.Utilities.Guard;

namespace Application.Client.Dialogs.SaveFileDialog.Models
{
    public class SaveFileDialogResult
    {
        private readonly SaveFileDialogResultType? _saveFileDialogResultType;
        public SaveFileDialogResultType SaveFileDialogResultType
        {
            get
            {
                Guard.ThrowIfNull(_saveFileDialogResultType, nameof(SaveFileDialogResultType));
                
                return _saveFileDialogResultType!.Value;
            }

            init => _saveFileDialogResultType = value;
        }

        private readonly string? _savedFilePath;
        public string SavedFilePath
        {
            get
            {
                Guard.ThrowIfNullOrWhitespace(_savedFilePath, nameof(SavedFilePath));
                
                return _savedFilePath!;
            }

            init
            {
                if (!_saveFileDialogResultType.HasValue)
                {
                    throw new InvalidOperationException($"Without the result type of the save file dialog, the {nameof(SavedFilePath)} property cannot be set!");
                }

                if (_saveFileDialogResultType.Value == SaveFileDialogResultType.Cancel && !string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException("It is not possible to set the saved file path when, the save file dialog result type is cancelled!");
                }

                _savedFilePath = value;
            }
        }

        public string SavedFileName => Path.GetFileName(_savedFilePath!);

        public string SavedFileNameWithoutExtension => Path.GetFileNameWithoutExtension(_savedFilePath!);
    }
}
