using Application.Utilities.FileReader.Models.Interfaces;

namespace Application.Utilities.FileReader.Models
{
    public class ReadTextFileModel : IFileReaderModel
    {
        private readonly string? _filePath;
        public string FilePath
        {
            get
            {
                Guard.Guard.ThrowIfNullOrWhitespace(_filePath, nameof(_filePath));

                return _filePath!;
            }

            init => _filePath = value;
        }
    }
}
