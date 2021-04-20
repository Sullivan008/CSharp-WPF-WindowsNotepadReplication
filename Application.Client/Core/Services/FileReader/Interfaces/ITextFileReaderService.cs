using System.Threading.Tasks;
using Application.Client.Core.Services.FileReader.Models.Interfaces;

namespace Application.Client.Core.Services.FileReader.Interfaces
{
    public interface ITextFileReaderService
    {
        Task<TContentType> ReadAsync<TContentType>(IFileReaderModel model);
    }
}
