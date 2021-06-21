using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Application.Client.Infrastructure.Commands;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ICommand _changeStatusBarVisibilityCommand;
        public ICommand ChangeStatusBarVisibilityCommand => _changeStatusBarVisibilityCommand ??= new RelayCommandAsync(ChangeStatusBarVisibilityCommandExecute);

        private async Task ChangeStatusBarVisibilityCommandExecute()
        {
            switch (StatusBar.Visibility)
            {
                case Visibility.Visible:
                    StatusBar.Visibility = Visibility.Collapsed;
                    break;
                case Visibility.Collapsed:
                    StatusBar.Visibility = Visibility.Visible;
                    break;
                default:
                    throw new NotImplementedException($"The following Status Bar Visibility change logic does not implemented! {StatusBar.Visibility}");
            }
            
            await Task.CompletedTask;
        }
    }
}
