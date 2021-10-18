using System;
using System.IO;
using System.Threading.Tasks;
using Application.Utilities.FileWriter.Abstractions;
using Application.Utilities.FileWriter.Interfaces;
using Application.Utilities.FileWriter.Models.Interfaces;

namespace Application.Utilities.FileWriter
{
    public class TextFileWriter : BaseFileWriter, ITextFileWriter
    {
        public override async Task WriteAsync<TContentType>(IFileWriterModel<TContentType> model)
        {
            string directoryPath = GetDirectoryPath(model.FilePath)!;

            if (!IsExistDirectory(directoryPath))
            {
                CreateDirectory(directoryPath);
            }

            await File.WriteAllTextAsync(model.FilePath, model.Content as string);
        }
    }
}
