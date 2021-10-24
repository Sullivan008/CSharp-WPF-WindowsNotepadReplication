using System.Threading.Tasks;
using Application.Utilities.FileReader.Models.Interfaces;

namespace Application.Utilities.FileReader.Interfaces
{
    public interface ITextFileReader
    {
        public Task<TContentType> ReadAsync<TContentType>(IFileReaderModel model);
    }
}
