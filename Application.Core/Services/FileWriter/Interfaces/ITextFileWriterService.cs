using System.Threading.Tasks;
using Application.Core.Services.FileWriter.Models.Interfaces;

namespace Application.Core.Services.FileWriter.Interfaces
{
    public interface ITextFileWriterService
    {
        Task WriteAsync<TContentType>(IFileWriterModel<TContentType> model);
    }
}
