using System;
using System.Threading.Tasks;
using System.Windows;
using Application.Client.Infrastructure.Commands;
using Application.Client.Windows.Main.ViewModels;

namespace Application.Client.Windows.Main.Commands.ViewMenu
{
    internal class ChangeStatusBarVisibilityCommand : AsyncCommandBase<MainWindowViewModel>
    {
        public ChangeStatusBarVisibilityCommand(MainWindowViewModel callerViewModel) : base(callerViewModel)
        { }

        public override async Task ExecuteAsync()
        {
            CallerViewModel.StatusBarViewModel.Visibility = CallerViewModel.StatusBarViewModel.Visibility switch
            {
                Visibility.Visible => Visibility.Collapsed,
                Visibility.Collapsed => Visibility.Visible,
                _ => throw new NotImplementedException($"The following Status Bar Visibility change logic does not implemented! {CallerViewModel.StatusBarViewModel.Visibility}"),
            };

            await Task.CompletedTask;
        }
    }
}