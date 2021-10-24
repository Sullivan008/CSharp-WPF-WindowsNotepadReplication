using Application.Client.Dialogs.OpenFileDialog.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Dialogs.OpenFileDialog.Extensions.DependencyInjection
{
    public static class OpenFileDialogServiceCollectionExtension
    {
        public static IServiceCollection AddOpenFileDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IOpenFileDialog, OpenFileDialog>();

            return @this;
        }
    }
}
