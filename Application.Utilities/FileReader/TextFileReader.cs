using System.IO;
using System.Threading.Tasks;
using Application.Utilities.FileReader.Abstractions;
using Application.Utilities.FileReader.Interfaces;
using Application.Utilities.FileReader.Models.Interfaces;

namespace Application.Utilities.FileReader
{
    public class TextFileReader : BaseFileReader, ITextFileReader
    {
        public override async Task<TContentType> ReadAsync<TContentType>(IFileReaderModel model)
        {
            if (!IsExistsFile(model.FilePath))
            {
                throw new FileNotFoundException("Could not find file!", model.FilePath);
            }

            return await GetFileContent<TContentType>(model.FilePath);
        }

        private static async Task<TContentType> GetFileContent<TContentType>(string filePath)
        {
            using StreamReader streamReader = new(filePath);

            return (TContentType)(object)await streamReader.ReadToEndAsync();
        }
    }
}
