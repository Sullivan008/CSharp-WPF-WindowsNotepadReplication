using System.Threading.Tasks;
using Application.Core.Services.FileReader.Models.Interfaces;

namespace Application.Core.Services.FileReader.Interfaces
{
    public interface ITextFileReaderService
    {
        Task<TContentType> ReadAsync<TContentType>(IFileReaderModel model);
    }
}
