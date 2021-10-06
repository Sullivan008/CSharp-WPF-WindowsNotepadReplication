using Application.Utilities.FileWriter.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Utilities.FileWriter.Extensions.DependencyInjection
{
    public static class FileWriterServiceCollectionExtension
    {
        public static IServiceCollection AddTextFileWriter(this IServiceCollection @this)
        {
            @this.AddTransient<ITextFileWriter, TextFileWriter>();

            return @this;
        }
    }
}
