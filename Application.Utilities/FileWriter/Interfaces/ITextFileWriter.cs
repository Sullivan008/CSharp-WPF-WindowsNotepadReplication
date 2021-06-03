using System.Threading.Tasks;
using Application.Utilities.FileWriter.Models.Interfaces;

namespace Application.Utilities.FileWriter.Interfaces
{
    public interface ITextFileWriter
    {
        Task WriteAsync<TContentType>(IFileWriterModel<TContentType> model);
    }
}
