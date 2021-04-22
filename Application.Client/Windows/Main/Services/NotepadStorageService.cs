using System;
using System.IO;
using Application.Client.Windows.Main.Services.Enums;
using Application.Client.Windows.Main.Services.Interfaces;

namespace Application.Client.Windows.Main.Services
{
    public class NotepadStorageService : INotepadStorageService
    {
        private DocumentState _documentState;

        public string UsedFilePath { get; private set; }

        public string UsedFileNameWithExtension => Path.GetFileName(UsedFilePath) ?? "Unnamed.txt";

        public string UsedFileNameWithoutExtension => Path.GetFileNameWithoutExtension(UsedFilePath) ?? "Unnamed";
        
        public bool HasUsedFile => !string.IsNullOrWhiteSpace(UsedFilePath);

        public bool HasDocumentModified => _documentState == DocumentState.Modified;

        public void SetUsedFilePath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), @"The value cannot be null!");
            }

            UsedFilePath = filePath;
        }

        public void SetDocumentState(DocumentState documentState)
        {
            _documentState = documentState;
        }
    }
}
