using System.IO;
using System.Threading.Tasks;
using Application.Core.Utilities.FileWriter.Abstractions;
using Application.Core.Utilities.FileWriter.Interfaces;
using Application.Core.Utilities.FileWriter.Models.Interfaces;

namespace Application.Core.Utilities.FileWriter
{
    public class TextFileWriter : BaseFileWriter, ITextFileWriter
    {
        public override async Task WriteAsync<TContentType>(IFileWriterModel<TContentType> model)
        {
            string directoryPath = GetDirectoryPath(model.FilePath);

            if (!IsExistDirectory(directoryPath))
            {
                CreateDirectory(directoryPath);
            }

            await File.WriteAllTextAsync(model.FilePath, model.Content as string);
        }
    }
}
