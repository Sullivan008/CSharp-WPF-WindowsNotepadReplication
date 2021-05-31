using Application.Client.Core.Dialogs.MessageDialog;
using Application.Client.Core.Dialogs.MessageDialog.Interfaces;
using Application.Client.Core.Dialogs.OpenFileDialog;
using Application.Client.Core.Dialogs.OpenFileDialog.Interfaces;
using Application.Client.Core.Dialogs.SaveFileDialog;
using Application.Client.Core.Dialogs.SaveFileDialog.Interfaces;
using Application.Client.Windows.Main;
using Application.Client.Windows.Main.Services;
using Application.Client.Windows.Main.Services.Interfaces;
using Application.Client.Windows.Main.ViewModels;
using Application.Client.Windows.Main.ViewModels.Interfaces;
using Application.Core.Utilities.FileReader;
using Application.Core.Utilities.FileReader.Interfaces;
using Application.Core.Utilities.FileWriter;
using Application.Core.Utilities.FileWriter.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Core.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddTransientServices(this IServiceCollection services)
        {
            services.AddTransient<ISaveFileDialog, SaveFileDialog>();
            services.AddTransient<IOpenFileDialog, OpenFileDialog>();
            services.AddTransient<IMessageDialog, MessageDialog>();

            services.AddTransient<ITextFileReader, TextFileReader>();
            services.AddTransient<ITextFileWriter, TextFileWriter>();

            return services;
        }

        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddSingletonServices(this IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();

            services.AddSingleton<INotepadStorageService, NotepadStorageService>();

            return services;
        }
    }
}
