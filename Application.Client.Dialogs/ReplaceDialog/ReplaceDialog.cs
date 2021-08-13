using System;
using System.Threading.Tasks;
using Application.Client.Dialogs.ReplaceDialog.Interfaces;
using Application.Client.Dialogs.ReplaceDialog.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Dialogs.ReplaceDialog
{
    public class ReplaceDialog : IReplaceDialog
    {
        private readonly IServiceProvider _serviceProvider;

        public ReplaceDialog(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task ShowAsync()
        {
            ReplaceWindow dialogWindow = _serviceProvider.GetRequiredService<ReplaceWindow>();

            dialogWindow.Show();

            return Task.CompletedTask;
        }
    }
}
