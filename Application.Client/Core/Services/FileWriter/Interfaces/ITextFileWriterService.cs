using System.Threading.Tasks;
using Application.Client.Core.Services.FileWriter.Models.Interfaces;

namespace Application.Client.Core.Services.FileWriter.Interfaces
{
    public interface ITextFileWriterService
    {
        Task WriteAsync<TContentType>(IFileWriterModel<TContentType> model);
    }
}
