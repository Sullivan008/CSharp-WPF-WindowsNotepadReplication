using System;
using Application.Core.Utilities.FileReader.Models.Interfaces;

namespace Application.Core.Utilities.FileReader.Models
{
    public class ReadTextFileModel : IFileReaderModel
    {
        private readonly string _filePath;
        public string FilePath
        {
            get => _filePath;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(FilePath), "The value cannot be null!");
                }

                _filePath = value;
            }
        }
    }
}
