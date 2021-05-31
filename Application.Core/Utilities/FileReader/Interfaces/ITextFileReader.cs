using System.Threading.Tasks;
using Application.Core.Utilities.FileReader.Models.Interfaces;

namespace Application.Core.Utilities.FileReader.Interfaces
{
    public interface ITextFileReader
    {
        Task<TContentType> ReadAsync<TContentType>(IFileReaderModel model);
    }
}
