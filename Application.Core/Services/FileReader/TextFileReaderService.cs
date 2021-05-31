using System.IO;
using System.Threading.Tasks;
using Application.Core.Services.FileReader.Abstractions;
using Application.Core.Services.FileReader.Interfaces;
using Application.Core.Services.FileReader.Models.Interfaces;

namespace Application.Core.Services.FileReader
{
    public class TextFileReaderService : BaseFileReader, ITextFileReaderService
    {
        public override async Task<TContentType> ReadAsync<TContentType>(IFileReaderModel model)
        {
            if (!IsExistsFile(model.FilePath))
            {
                throw new FileNotFoundException("Could not find file!", model.FilePath);
            }

            return await GetFileContent<TContentType>(model.FilePath);
        }

        public static async Task<TContentType> GetFileContent<TContentType>(string filePath)
        {
            using StreamReader streamReader = new(filePath);

            return (TContentType)(object)await streamReader.ReadToEndAsync();
        }
    }
}
