using System;
using Application.Utilities.FileWriter.Models.Interfaces;

namespace Application.Utilities.FileWriter.Models
{
    public class WriteTextFileModel : IFileWriterModel<string>
    {
        private readonly string _filePath;
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

        public string Content { get; init; }
    }
}
