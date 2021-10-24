using System;
using System.IO;
using Application.Client.Dialogs.OpenFileDialog.Enums;
using Application.Utilities.Guard;

namespace Application.Client.Dialogs.OpenFileDialog.Models
{
    public class OpenFileDialogResult
    {
        private readonly OpenFileDialogResultType? _openFileDialogResultType;
        public OpenFileDialogResultType OpenFileDialogResultType
        {
            get
            {
                Guard.ThrowIfNull(_openFileDialogResultType, nameof(OpenFileDialogResultType));

                return _openFileDialogResultType!.Value;
            }

            init => _openFileDialogResultType = value;
        }

        private readonly string? _filePath;
        public string FilePath
        {
            get
            {
                Guard.ThrowIfNullOrWhitespace(_filePath, nameof(FilePath));

                return _filePath!;
            }

            init
            {
                if (!_openFileDialogResultType.HasValue)
                {
                    throw new InvalidOperationException($"Without the result type of the save file dialog, the {nameof(FilePath)} property cannot be set!");
                }

                if (_openFileDialogResultType.Value == OpenFileDialogResultType.Cancel && !string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException("It is not possible to set the file path when, the save file dialog result type is cancelled!");
                }

                _filePath = value;
            }
        }

        public string OpenedFileName => Path.GetFileName(_filePath)!;

        public string OpenedFileNameWithoutExtension => Path.GetFileNameWithoutExtension(_filePath)!;
    }
}
