using Application.Client.Dialogs.FontDialog.Interfaces;
using Application.Client.Dialogs.FontDialog.Services;
using Application.Client.Dialogs.FontDialog.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Dialogs.FontDialog.Extensions.DependencyInjection
{
    public static class FontDialogServiceCollectionExtension
    {
        public static IServiceCollection AddFontDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IFontDialog, FontDialog>();
            @this.AddSingleton<IFontDialogSettingsService, FontDialogSettingsService>();

            return @this;
        }
    }
}
