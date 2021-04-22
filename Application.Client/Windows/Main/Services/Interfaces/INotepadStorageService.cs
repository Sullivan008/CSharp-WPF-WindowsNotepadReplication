using Application.Client.Windows.Main.Services.Enums;

namespace Application.Client.Windows.Main.Services.Interfaces
{
    public interface INotepadStorageService
    {
        string UsedFilePath { get; }

        string UsedFileNameWithExtension { get; }

        string UsedFileNameWithoutExtension { get; }

        bool HasUsedFile { get; }

        bool HasDocumentModified { get; }

        void SetUsedFilePath(string filePath);

        void SetDocumentState(DocumentState documentState);
    }
}
