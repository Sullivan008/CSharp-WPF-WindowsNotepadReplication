using System;
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
                if (string.IsNullOrWhiteSpace(_filePath))
                {
                    throw new ArgumentNullException(nameof(FilePath), "The value cannot be null!");
                }

                return _filePath;
            }

            init => _filePath = value;
        }
    }
}
