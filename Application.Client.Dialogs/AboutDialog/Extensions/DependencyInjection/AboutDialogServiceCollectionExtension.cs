using Application.Client.Dialogs.AboutDialog.Interfaces;
using Application.Client.Dialogs.AboutDialog.Windows;
using Application.Client.Dialogs.AboutDialog.Windows.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Dialogs.AboutDialog.Extensions.DependencyInjection
{
    public static class AboutDialogServiceCollectionExtension
    {
        public static IServiceCollection AddAboutDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IAboutDialog, AboutDialog>();

            @this.AddTransient<AboutWindowViewModel>();
            @this.AddTransient(x => new AboutWindow
            {
                DataContext = x.GetRequiredService<AboutWindowViewModel>()
            });

            return @this;
        }
    }
}
