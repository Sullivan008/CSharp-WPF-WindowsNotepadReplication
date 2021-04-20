namespace Application.Client.Windows.Main.Services.Interfaces
{
    public interface INotepadStorageService
    {
        string UsedFilePath { get; }

        string UsedFileName { get; }

        bool HasUsedFile { get; }

        void SetUsedFilePath(string filePath);
    }
}
