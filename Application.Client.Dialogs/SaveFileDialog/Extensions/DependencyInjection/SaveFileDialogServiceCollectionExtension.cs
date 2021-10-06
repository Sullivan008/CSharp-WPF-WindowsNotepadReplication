using Application.Client.Dialogs.SaveFileDialog.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Dialogs.SaveFileDialog.Extensions.DependencyInjection
{
    public static class SaveFileDialogServiceCollectionExtension
    {
        public static IServiceCollection AddSaveFileDialog(this IServiceCollection @this)
        {
            @this.AddTransient<ISaveFileDialog, SaveFileDialog>();

            return @this;
        }
    }
}
