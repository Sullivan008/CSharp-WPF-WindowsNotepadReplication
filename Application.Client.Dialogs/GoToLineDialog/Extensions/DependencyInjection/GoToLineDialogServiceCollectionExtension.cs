using Application.Client.Dialogs.GoToLineDialog.Interfaces;
using Application.Client.Dialogs.GoToLineDialog.Windows;
using Application.Client.Dialogs.GoToLineDialog.Windows.ViewModels;
using Application.Client.Dialogs.GoToLineDialog.Windows.ViewModels.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Dialogs.GoToLineDialog.Extensions.DependencyInjection
{
    public static class GoToLineDialogServiceCollectionExtension
    {
        public static IServiceCollection AddGoToLineDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IGoToLineDialog, GoToLineDialog>();

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
