using Application.Utilities.FileWriter.Models.Interfaces;

namespace Application.Utilities.FileWriter.Models
{
    public class WriteTextFileModel : IFileWriterModel<string>
    {
        private readonly string? _filePath;
        public string FilePath
        {
            get
            {
                Guard.Guard.ThrowIfNullOrWhitespace(_filePath, nameof(FilePath));

                return _filePath!;
            }

            init => _filePath = value;
        }

        public string Content { get; init; } = string.Empty;
    }
}
