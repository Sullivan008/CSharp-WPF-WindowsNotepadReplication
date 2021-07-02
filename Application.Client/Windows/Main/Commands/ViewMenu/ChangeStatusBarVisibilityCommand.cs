using System;
using System.Threading.Tasks;
using System.Windows;
using Application.Client.Infrastructure.Commands;
using Application.Client.Windows.Main.ViewModels;

namespace Application.Client.Windows.Main.Commands.ViewMenu
{
    public class ChangeStatusBarVisibilityCommand : AsyncCommandBase<MainWindowViewModel>
    {
        public ChangeStatusBarVisibilityCommand(MainWindowViewModel callerViewModel) : base(callerViewModel)
        { }

        public override async Task ExecuteAsync()
        {
            switch (CallerViewModel.StatusBar.Visibility)
            {
                case Visibility.Visible:
                    CallerViewModel.StatusBar.Visibility = Visibility.Collapsed;
                    break;
                case Visibility.Collapsed:
                    CallerViewModel.StatusBar.Visibility = Visibility.Visible;
                    break;
                default:
                    throw new NotImplementedException($"The following Status Bar Visibility change logic does not implemented! {CallerViewModel.StatusBar.Visibility}");
            }

            await Task.CompletedTask;
        }
    }
}