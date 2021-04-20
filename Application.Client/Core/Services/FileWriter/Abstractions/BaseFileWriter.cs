using System.IO;
using System.Threading.Tasks;
using Application.Client.Core.Services.FileWriter.Models.Interfaces;

namespace Application.Client.Core.Services.FileWriter.Abstractions
{
    public abstract class BaseFileWriter
    {
        protected static bool IsExistDirectory(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }

        protected static void CreateDirectory(string directoryPath)
        {
            Directory.CreateDirectory(directoryPath);
        }

        protected static string GetDirectoryPath(string filePath)
        {
            return Path.GetDirectoryName(filePath);
        }

        public abstract Task WriteAsync<TContentType>(IFileWriterModel<TContentType> model);
    }
}
