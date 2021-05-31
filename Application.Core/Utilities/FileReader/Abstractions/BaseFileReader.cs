using System.IO;
using System.Threading.Tasks;
using Application.Core.Utilities.FileReader.Models.Interfaces;

namespace Application.Core.Utilities.FileReader.Abstractions
{
    public abstract class BaseFileReader
    {
        protected static bool IsExistsFile(string filePath)
        {
            return File.Exists(filePath);
        }

        public abstract Task<TContentType> ReadAsync<TContentType>(IFileReaderModel model);
    }
}
