using System.IO;
using System.Threading.Tasks;
using Application.Core.Services.FileWriter.Abstractions;
using Application.Core.Services.FileWriter.Interfaces;
using Application.Core.Services.FileWriter.Models.Interfaces;

namespace Application.Core.Services.FileWriter
{
    public class TextFileWriterService : BaseFileWriter, ITextFileWriterService
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
