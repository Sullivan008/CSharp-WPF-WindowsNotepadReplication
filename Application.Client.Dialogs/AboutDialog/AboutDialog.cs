using System;
using System.Threading.Tasks;
using Application.Client.Dialogs.AboutDialog.Enums;
using Application.Client.Dialogs.AboutDialog.Exceptions;
using Application.Client.Dialogs.AboutDialog.Interfaces;
using Application.Client.Dialogs.AboutDialog.Models;
using Application.Client.Dialogs.AboutDialog.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Dialogs.AboutDialog
{
    internal class AboutDialog : IAboutDialog
    {
        private readonly IServiceProvider _serviceProvider;

        public AboutDialog(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<AboutDialogResult> ShowDialogAsync()
        {
            AboutWindow dialogWindow = _serviceProvider.GetRequiredService<AboutWindow>();

            return dialogWindow.ShowDialog() switch
            {
                true => OnTrueResult(),
                false => OnFalseResult(),
                _ => throw new AboutDialogUnknownResultTypeException("An unknown error occurred while reading the result of the dialog box!")
            };
        }

        private static Task<AboutDialogResult> OnTrueResult()
        {
            return Task.FromResult(new AboutDialogResult { AboutDialogResultType = AboutDialogResultType.Ok });
        }

        private static Task<AboutDialogResult> OnFalseResult()
        {
            return Task.FromResult(new AboutDialogResult { AboutDialogResultType = AboutDialogResultType.Close });
        }
    }
}
