using Application.Client.Core.Dialogs.SaveFileDialog;
using Application.Client.Core.Dialogs.SaveFileDialog.Interfaces;
using Application.Client.Windows.Main;
using Application.Client.Windows.Main.ViewModels;
using Application.Client.Windows.Main.ViewModels.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Core.Application.Providers
{
    public static class ServiceProviders
    {
        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddSingletonServices(this IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();

            services.AddSingleton<ISaveFileDialogService, SaveFileDialogService>();

            return services;
        }
    }
}
