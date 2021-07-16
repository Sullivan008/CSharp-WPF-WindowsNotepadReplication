using System;
using System.Threading.Tasks;
using Application.Client.Dialogs.FindDialog.Delegates;
using Application.Client.Dialogs.FindDialog.Interfaces;
using Application.Client.Dialogs.FindDialog.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Dialogs.FindDialog
{
    public class FindDialog : IFindDialog
    {
        private readonly IServiceProvider _serviceProvider;

        public FindDialog(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public event OnFindNextEventHandler OnFindNextEvent;

        public Task ShowAsync()
        {
            FindWindow dialogWindow = _serviceProvider.GetRequiredService<FindWindow>();
            dialogWindow.Show();

            return Task.CompletedTask;
        }
    }
}
