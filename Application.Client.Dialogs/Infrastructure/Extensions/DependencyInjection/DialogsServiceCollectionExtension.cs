using Application.Client.Dialogs.ColorDialog.Interfaces;
using Application.Client.Dialogs.ColorDialog.Services;
using Application.Client.Dialogs.ColorDialog.Services.Interfaces;
using Application.Client.Dialogs.FindDialog.Interfaces;
using Application.Client.Dialogs.FindDialog.Services;
using Application.Client.Dialogs.FindDialog.Services.Interfaces;
using Application.Client.Dialogs.FindDialog.Windows;
using Application.Client.Dialogs.FindDialog.Windows.ViewModels;
using Application.Client.Dialogs.FindDialog.Windows.ViewModels.Validator;
using Application.Client.Dialogs.FontDialog.Interfaces;
using Application.Client.Dialogs.FontDialog.Services;
using Application.Client.Dialogs.FontDialog.Services.Interfaces;
using Application.Client.Dialogs.GoToLineDialog.Interfaces;
using Application.Client.Dialogs.GoToLineDialog.Windows;
using Application.Client.Dialogs.GoToLineDialog.Windows.ViewModels;
using Application.Client.Dialogs.GoToLineDialog.Windows.ViewModels.Validator;
using Application.Client.Dialogs.MessageDialog.Interfaces;
using Application.Client.Dialogs.OpenFileDialog.Interfaces;
using Application.Client.Dialogs.ReplaceDialog.Interfaces;
using Application.Client.Dialogs.ReplaceDialog.Windows;
using Application.Client.Dialogs.ReplaceDialog.Windows.ViewModels;
using Application.Client.Dialogs.SaveFileDialog.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Dialogs.Infrastructure.Extensions.DependencyInjection
{
    public static class DialogsServiceCollectionExtension
    {
        public static IServiceCollection AddMessageDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IMessageDialog, MessageDialog.MessageDialog>();

            return @this;
        }

        public static IServiceCollection AddSaveFileDialog(this IServiceCollection @this)
        {
            @this.AddTransient<ISaveFileDialog, SaveFileDialog.SaveFileDialog>();

            return @this;
        }

        public static IServiceCollection AddOpenFileDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IOpenFileDialog, OpenFileDialog.OpenFileDialog>();

            return @this;
        }

        public static IServiceCollection AddFontDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IFontDialog, FontDialog.FontDialog>();
            @this.AddSingleton<IFontDialogSettingsService, FontDialogSettingsService>();

            return @this;
        }

        public static IServiceCollection AddFindDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IFindDialog, FindDialog.FindDialog>();

            @this.AddTransient<FindWindowViewModel>();
            @this.AddTransient<IValidator<FindWindowViewModel>, FindWindowViewModelValidator>();

            @this.AddTransient(x => new FindWindow
            {
                DataContext = x.GetRequiredService<FindWindowViewModel>()
            });

            @this.AddSingleton<IFindDialogSettingsService, FindDialogSettingsService>();

            return @this;
        }

        public static IServiceCollection AddColorDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IColorDialog, ColorDialog.ColorDialog>();
            @this.AddSingleton<IColorDialogSettingsService, ColorDialogSettingsService>();

            return @this;
        }

        public static IServiceCollection AddReplaceDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IReplaceDialog, ReplaceDialog.ReplaceDialog>();

            @this.AddTransient<ReplaceWindowViewModel>();

            @this.AddTransient(x => new ReplaceWindow
            {
                DataContext = x.GetRequiredService<ReplaceWindowViewModel>()
            });

            return @this;
        }

        public static IServiceCollection AddGoToLineDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IGoToLineDialog, GoToLineDialog.GoToLineDialog>();

            @this.AddTransient<GoToLineWindowViewModel>();
            @this.AddTransient<IValidator<GoToLineWindowViewModel>, GoToLineWindowViewModelValidator>();

            @this.AddTransient(x => new GoToLineWindow
            {
                DataContext = x.GetRequiredService<GoToLineWindowViewModel>()
            });

            return @this;
        }
    }
}
