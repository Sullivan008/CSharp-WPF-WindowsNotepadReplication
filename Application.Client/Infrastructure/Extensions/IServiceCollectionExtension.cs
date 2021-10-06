using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Application.Client.Cache.Infrastructure.Repository.Interfaces;
using Application.Client.Cache.Infrastructure.Services;
using Application.Client.Cache.Infrastructure.Services.Interfaces;
using Application.Client.Services.DocInfo;
using Application.Client.Services.DocInfo.Interfaces;
using Application.Client.Services.FindDialogSearchTerms;
using Application.Client.Services.FindDialogSearchTerms.Interfaces;
using Application.Client.Windows.Main;
using Application.Client.Windows.Main.ViewModels;
using Application.Client.Windows.Main.ViewModels.InputTextBox;
using Application.Client.Windows.Main.ViewModels.Settings;
using Application.Client.Windows.Main.ViewModels.StatusBar;
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

        public static IServiceCollection AddCacheServices(this IServiceCollection @this)
        {
            @this.AddSingleton<IApplicationCacheService, ApplicationCacheService>();

            return @this;
        }

        public static IServiceCollection AddCacheRepositories(this IServiceCollection @this)
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
                    @this.AddSingleton(implementedInterface, definedType);
                }
            }

            return @this;
        }

        public static IServiceCollection AddServices(this IServiceCollection @this)
        {
            @this.AddSingleton<IDocInfoService, DocInfoService>();
            @this.AddSingleton<IFindDialogSearchTermsService, FindDialogSearchTermsService>();

            return @this;
        }

        public static IServiceCollection AddFileReaders(this IServiceCollection @this)
        {
            @this.AddTransient<ITextFileReader, TextFileReader>();

            return @this;
        }

        public static IServiceCollection AddFileWriters(this IServiceCollection @this)
        {
            @this.AddTransient<ITextFileWriter, TextFileWriter>();

            return @this;
        }
    }
}
