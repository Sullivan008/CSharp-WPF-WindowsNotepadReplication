using Application.Client.Dialogs.ReplaceDialog.Interfaces;
using Application.Client.Dialogs.ReplaceDialog.Windows;
using Application.Client.Dialogs.ReplaceDialog.Windows.ViewModels;
using Application.Client.Dialogs.ReplaceDialog.Windows.ViewModels.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Dialogs.ReplaceDialog.Extensions.DependencyInjection
{
    public static class ReplaceDialogServiceCollectionExtension
    {
        public static IServiceCollection AddReplaceDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IReplaceDialog, ReplaceDialog>();

            @this.AddTransient<ReplaceWindowViewModel>();
            @this.AddTransient<IValidator<ReplaceWindowViewModel>, ReplaceWindowViewModelValidator>();

            @this.AddTransient(x => new ReplaceWindow
            {
                DataContext = x.GetRequiredService<ReplaceWindowViewModel>()
            });

            return @this;
        }
    }
}
