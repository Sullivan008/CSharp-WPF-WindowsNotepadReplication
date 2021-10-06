using Application.Client.Windows.Main;
using Application.Client.Windows.Main.ViewModels;
using Application.Client.Windows.Main.ViewModels.InputTextBox;
using Application.Client.Windows.Main.ViewModels.Settings;
using Application.Client.Windows.Main.ViewModels.StatusBar;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Infrastructure.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddMainWindow(this IServiceCollection @this)
        {
            @this.AddSingleton<MainWindowViewModel>();
            @this.AddSingleton(x => new MainWindow
            {
                DataContext = x.GetRequiredService<MainWindowViewModel>()
            });

            @this.AddSubViewModelsToMainWindowViewModel();

            return @this;
        }

        private static void AddSubViewModelsToMainWindowViewModel(this IServiceCollection @this)
        {
            @this.AddTransient<StatusBarViewModel>();
            @this.AddTransient<TextOptionsViewModel>();
            @this.AddTransient<InputTextBoxViewModel>();
            @this.AddTransient<WindowSettingsViewModel>();
        }
    }
}
