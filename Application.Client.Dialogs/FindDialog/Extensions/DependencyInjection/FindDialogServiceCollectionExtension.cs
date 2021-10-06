using Application.Client.Dialogs.FindDialog.Interfaces;
using Application.Client.Dialogs.FindDialog.Services;
using Application.Client.Dialogs.FindDialog.Services.Interfaces;
using Application.Client.Dialogs.FindDialog.Windows;
using Application.Client.Dialogs.FindDialog.Windows.ViewModels;
using Application.Client.Dialogs.FindDialog.Windows.ViewModels.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Dialogs.FindDialog.Extensions.DependencyInjection
{
    public static class FindDialogServiceCollectionExtension
    {
        public static IServiceCollection AddFindDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IFindDialog, FindDialog>();

            @this.AddTransient<FindWindowViewModel>();
            @this.AddTransient<IValidator<FindWindowViewModel>, FindWindowViewModelValidator>();

            @this.AddTransient(x => new FindWindow
            {
                DataContext = x.GetRequiredService<FindWindowViewModel>()
            });

            @this.AddSingleton<IFindDialogSettingsService, FindDialogSettingsService>();

            return @this;
        }
    }
}
