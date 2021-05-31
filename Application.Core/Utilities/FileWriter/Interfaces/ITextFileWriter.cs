using System.Threading.Tasks;
using Application.Core.Utilities.FileWriter.Models.Interfaces;

namespace Application.Core.Utilities.FileWriter.Interfaces
{
    public interface ITextFileWriter
    {
        Task WriteAsync<TContentType>(IFileWriterModel<TContentType> model);
    }
}
