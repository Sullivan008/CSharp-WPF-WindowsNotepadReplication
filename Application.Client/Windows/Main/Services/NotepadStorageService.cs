using System;
using System.IO;
using Application.Client.Windows.Main.Services.Interfaces;

namespace Application.Client.Windows.Main.Services
{
    public class NotepadStorageService : INotepadStorageService
    {
        public string UsedFilePath { get; private set; }

        public string UsedFileName => Path.GetFileNameWithoutExtension(UsedFilePath);

        public bool HasUsedFile => !string.IsNullOrWhiteSpace(UsedFilePath);

        public void SetUsedFilePath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), @"The value cannot be null!");
            }

            UsedFilePath = filePath;
        }
    }
}
