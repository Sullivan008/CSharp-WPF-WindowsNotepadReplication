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
using Application.Client.Dialogs.FindDialog;
using Application.Client.Dialogs.FindDialog.Interfaces;
using Application.Client.Dialogs.FindDialog.Windows;
using Application.Client.Dialogs.FindDialog.Windows.ViewModels;
using Application.Client.Dialogs.FindDialog.Windows.ViewModels.Validator;
using Application.Client.Dialogs.FontDialog;
using Application.Client.Dialogs.FontDialog.Interfaces;
using Application.Client.Dialogs.FontDialog.Services;
using Application.Client.Dialogs.FontDialog.Services.Interfaces;
using Application.Client.Dialogs.GoToLineDialog;
using Application.Client.Dialogs.GoToLineDialog.Interfaces;
using Application.Client.Dialogs.GoToLineDialog.Windows;
using Application.Client.Dialogs.GoToLineDialog.Windows.ViewModels;
using Application.Client.Dialogs.GoToLineDialog.Windows.ViewModels.Validator;
using Application.Client.Dialogs.MessageDialog;
using Application.Client.Dialogs.MessageDialog.Interfaces;
using Application.Client.Dialogs.OpenFileDialog;
using Application.Client.Dialogs.OpenFileDialog.Interfaces;
using Application.Client.Dialogs.SaveFileDialog;
using Application.Client.Dialogs.SaveFileDialog.Interfaces;
using Application.Client.Services;
using Application.Client.Services.Interfaces;
using Application.Client.Services.SearchTerms;
using Application.Client.Services.SearchTerms.Interfaces;
using Application.Client.Windows.Main;
using Application.Client.Windows.Main.ViewModels;
using Application.Client.Windows.Main.ViewModels.Settings;
using Application.Utilities.FileReader;
using Application.Utilities.FileReader.Interfaces;
using Application.Utilities.FileWriter;
using Application.Utilities.FileWriter.Interfaces;
using FluentValidation;
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
            services.AddTransient<WindowSettingsViewModel>();

            return services;
        }

        public static IServiceCollection AddDialogs(this IServiceCollection services)
        {
            services.AddTransient<IFontDialog, FontDialog>();
            services.AddTransient<IColorDialog, ColorDialog>();
            services.AddTransient<IMessageDialog, MessageDialog>();
            services.AddTransient<ISaveFileDialog, SaveFileDialog>();
            services.AddTransient<IOpenFileDialog, OpenFileDialog>();

            services.AddGoToLineDialog();
            services.AddFindDialog();

            return services;
        }

        private static IServiceCollection AddGoToLineDialog(this IServiceCollection services)
        {
            services.AddTransient<GoToLineWindowViewModel>();
            services.AddTransient<IGoToLineDialog, GoToLineDialog>();
            services.AddTransient(x => new GoToLineWindow
            {
                DataContext = x.GetRequiredService<GoToLineWindowViewModel>()
            });
            services.AddScoped<IValidator<GoToLineWindowViewModel>, GoToLineWindowViewModelValidator>();

            return services;
        }

        private static IServiceCollection AddFindDialog(this IServiceCollection services)
        {
            services.AddTransient<FindWindowViewModel>();
            services.AddTransient<IFindDialog, FindDialog>();
            services.AddTransient(x => new FindWindow
            {
                DataContext = x.GetRequiredService<FindWindowViewModel>()
            });
            services.AddScoped<IValidator<FindWindowViewModel>, FindWindowViewModelValidator>();

            return services;
        }

        public static IServiceCollection AddCacheServices(this IServiceCollection services)
        {
            services.AddSingleton<IApplicationCacheService, ApplicationCacheService>();

            services.AddSingleton<IDocInfoService, DocInfoService>();
            services.AddSingleton<IFontDialogSettingsService, FontDialogSettingsService>();
            services.AddSingleton<IColorDialogSettingsService, ColorDialogSettingsService>();
            services.AddSingleton<ISearchTermsService, SearchTermsService>();

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
