using Application.Client.Dialogs.ColorDialog.Interfaces;
using Application.Client.Dialogs.ColorDialog.Services;
using Application.Client.Dialogs.ColorDialog.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Dialogs.ColorDialog.Extensions.DependencyInjection
{
    public static class ColorDialogServiceCollectionExtension
    {
        public static IServiceCollection AddColorDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IColorDialog, ColorDialog>();
            @this.AddSingleton<IColorDialogSettingsService, ColorDialogSettingsService>();

            return @this;
        }
    }
}
