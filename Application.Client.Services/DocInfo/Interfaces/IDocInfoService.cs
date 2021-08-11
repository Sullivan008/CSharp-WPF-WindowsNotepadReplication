namespace Application.Client.Services.DocInfo.Interfaces
{
    public interface IDocInfoService
    {
        public string UsedFilePath { get; }

        public string UsedFileNameWithExtension { get; }

        public string UsedFileNameWithoutExtension { get; }

        public bool IsModifiedDocument { get; }

        public bool IsOpenedDocument { get; }

        public int ContentLength { get; }

        public int ContentLines { get; }

        public void SetDefaultDocInfo();

        public void SetFilePath(string filePath);

        public void SetModifiedDocumentState();

        public void SetUnmodifiedDocumentState();

        public void SetContentLength(int contentLength);

        public void SetContentLines(int contentLines);
    }
}
