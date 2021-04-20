using System;
using Application.Client.Core.Services.FileWriter.Models.Interfaces;

namespace Application.Client.Core.Services.FileWriter.Models
{
    public class WriteTextFileModel : IFileWriterModel<string>
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

        public string Content { get; init; }
    }
}
