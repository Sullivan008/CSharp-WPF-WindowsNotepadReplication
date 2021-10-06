using System;
using System.Threading.Tasks;
using Application.Client.Dialogs.GoToLineDialog.Enums;
using Application.Client.Dialogs.GoToLineDialog.Exceptions;
using Application.Client.Dialogs.GoToLineDialog.Interfaces;
using Application.Client.Dialogs.GoToLineDialog.Models;
using Application.Client.Dialogs.GoToLineDialog.Windows;
using Application.Client.Dialogs.GoToLineDialog.Windows.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Dialogs.GoToLineDialog
{
    internal class GoToLineDialog : IGoToLineDialog
    {
        private readonly IServiceProvider _serviceProvider;

        public GoToLineDialog(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<GoToLineDialogResult> ShowDialogAsync()
        {
            GoToLineWindow dialogWindow = _serviceProvider.GetRequiredService<GoToLineWindow>();

            return dialogWindow.ShowDialog() switch
            {
                true => OnTrueResult(dialogWindow),
                false => OnFalseResult(),
                _ => throw new GoToLineDialogUnknownResultTypeException("An unknown error occurred while reading the result of the dialog box!")
            };
        }

        private static Task<GoToLineDialogResult> OnTrueResult(GoToLineWindow dialogWindow)
        {
            return Task.FromResult(new GoToLineDialogResult
            {
                GoToLineDialogResultType = GoToLineDialogResultType.GoToLine,
                LineNumber = ((GoToLineWindowViewModel)dialogWindow.DataContext).LineNumber.Value
            });
        }

        private static Task<GoToLineDialogResult> OnFalseResult()
        {
            return Task.FromResult(new GoToLineDialogResult
            {
                GoToLineDialogResultType = GoToLineDialogResultType.Cancel
            });
        }
    }
}
