using Application.Utilities.FileReader.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Utilities.FileReader.Extensions.DependencyInjection
{
    public static class FileReaderServiceCollectionExtension
    {
        public static IServiceCollection AddTextFileReader(this IServiceCollection @this)
        {
            @this.AddTransient<ITextFileReader, TextFileReader>();

            return @this;
        }
    }
}
