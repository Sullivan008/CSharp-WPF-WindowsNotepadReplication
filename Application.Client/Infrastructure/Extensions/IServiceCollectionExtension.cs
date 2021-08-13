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
using Application.Client.Dialogs.FindDialog.Services;
using Application.Client.Dialogs.FindDialog.Services.Interfaces;
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
using Application.Client.Dialogs.ReplaceDialog;
using Application.Client.Dialogs.ReplaceDialog.Interfaces;
using Application.Client.Dialogs.SaveFileDialog;
using Application.Client.Dialogs.SaveFileDialog.Interfaces;
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

        public static IServiceCollection AddDialogs(this IServiceCollection @this)
        {
            @this.AddTransient<IMessageDialog, MessageDialog>();
            @this.AddTransient<ISaveFileDialog, SaveFileDialog>();
            @this.AddTransient<IOpenFileDialog, OpenFileDialog>();

            @this.AddFontDialog();
            @this.AddFindDialog();
            @this.AddColorDialog();
            @this.AddReplaceDialog();
            @this.AddGoToLineDialog();

            return @this;
        }

        private static void AddFontDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IFontDialog, FontDialog>();
            @this.AddSingleton<IFontDialogSettingsService, FontDialogSettingsService>();
        }

        private static void AddFindDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IFindDialog, FindDialog>();

            @this.AddTransient<FindWindowViewModel>();
            @this.AddTransient<IValidator<FindWindowViewModel>, FindWindowViewModelValidator>();

            @this.AddTransient(x => new FindWindow
            {
                DataContext = x.GetRequiredService<FindWindowViewModel>()
            });
            
            @this.AddSingleton<IFindDialogSettingsService, FindDialogSettingsService>();
        }

        private static void AddColorDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IColorDialog, ColorDialog>();
            @this.AddSingleton<IColorDialogSettingsService, ColorDialogSettingsService>();
        }

        private static void AddGoToLineDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IGoToLineDialog, GoToLineDialog>();

            @this.AddTransient<GoToLineWindowViewModel>();
            @this.AddTransient<IValidator<GoToLineWindowViewModel>, GoToLineWindowViewModelValidator>();

            @this.AddTransient(x => new GoToLineWindow
            {
                DataContext = x.GetRequiredService<GoToLineWindowViewModel>()
            });
        }

        private static void AddReplaceDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IReplaceDialog, ReplaceDialog>();
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
