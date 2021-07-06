using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Application.Client.Cache.Infrastructure.Repository.Interfaces;
using Application.Client.Cache.Infrastructure.Services;
using Application.Client.Cache.Infrastructure.Services.Interfaces;
using Application.Client.Dialogs.ColorDialog;
using Application.Client.Dialogs.ColorDialog.Interfaces;
using Application.Client.Dialogs.ColorDialog.Services;
using Application.Client.Dialogs.ColorDialog.Services.Interfaces;
using Application.Client.Dialogs.FontDialog;
using Application.Client.Dialogs.FontDialog.Interfaces;
using Application.Client.Dialogs.FontDialog.Services;
using Application.Client.Dialogs.FontDialog.Services.Interfaces;
using Application.Client.Dialogs.MessageDialog;
using Application.Client.Dialogs.MessageDialog.Interfaces;
using Application.Client.Dialogs.OpenFileDialog;
using Application.Client.Dialogs.OpenFileDialog.Interfaces;
using Application.Client.Dialogs.SaveFileDialog;
using Application.Client.Dialogs.SaveFileDialog.Interfaces;
using Application.Client.Services;
using Application.Client.Services.Interfaces;
using Application.Client.Windows.Main;
using Application.Client.Windows.Main.ViewModels;
using Application.Utilities.FileReader;
using Application.Utilities.FileReader.Interfaces;
using Application.Utilities.FileWriter;
using Application.Utilities.FileWriter.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Infrastructure.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddWindows(this IServiceCollection services)
        {
            services.AddSingleton(x => new MainWindow
            {
                DataContext = x.GetRequiredService<MainWindowViewModel>()
            });

            return services;
        }

        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddTransient<StatusBarViewModel>();
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<TextOptionsViewModel>();
            services.AddTransient<InputTextBoxViewModel>();

            return services;
        }

        public static IServiceCollection AddDialogs(this IServiceCollection services)
        {
            services.AddTransient<IFontDialog, FontDialog>();
            services.AddTransient<IColorDialog, ColorDialog>();
            services.AddTransient<IMessageDialog, MessageDialog>();
            services.AddTransient<ISaveFileDialog, SaveFileDialog>();
            services.AddTransient<IOpenFileDialog, OpenFileDialog>();

            return services;
        }

        public static IServiceCollection AddCacheServices(this IServiceCollection services)
        {
            services.AddSingleton<IApplicationCacheService, ApplicationCacheService>();
            services.AddSingleton<IDocInfoService, DocInfoService>();
            services.AddSingleton<IFontDialogSettingsService, FontDialogSettingsService>();
            services.AddSingleton<IColorDialogSettingsService, ColorDialogSettingsService>();

            return services;
        }

        public static IServiceCollection AddCacheRepositories(this IServiceCollection services)
        {
            Type repositoryType = typeof(ICacheRepository<>);

            List<TypeInfo> definedTypes = repositoryType.Assembly.DefinedTypes
                .Where(x => x.IsClass)
                .Where(x => !x.IsAbstract)
                .Where(x => x != repositoryType)
                .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == repositoryType))
                .ToList();

            foreach (TypeInfo definedType in definedTypes)
            {
                foreach (Type implementedInterface in definedType.ImplementedInterfaces)
                {
                    services.AddSingleton(implementedInterface, definedType);
                }
            }

            return services;
        }

        public static IServiceCollection AddFileReaders(this IServiceCollection services)
        {
            services.AddTransient<ITextFileReader, TextFileReader>();

            return services;
        }

        public static IServiceCollection AddFileWriters(this IServiceCollection services)
        {
            services.AddTransient<ITextFileWriter, TextFileWriter>();

            return services;
        }
    }
}
