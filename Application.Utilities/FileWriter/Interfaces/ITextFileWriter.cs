using System.Threading.Tasks;
using Application.Utilities.FileWriter.Models.Interfaces;

namespace Application.Utilities.FileWriter.Interfaces
{
    public interface ITextFileWriter
    {
        public Task WriteAsync<TContentType>(IFileWriterModel<TContentType> model);
    }
}
