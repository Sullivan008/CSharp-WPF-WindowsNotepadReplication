using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Application.Client.Infrastructure.Commands;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ICommand _changeTextWrappingCommand;
        public ICommand ChangeTextWrappingCommand => _changeTextWrappingCommand ??= new RelayCommandAsync(ChangeTextWrappingCommandExecute);

        private async Task ChangeTextWrappingCommandExecute()
        {
            switch (TextWrapping)
            {
                case TextWrapping.NoWrap:
                    TextWrapping = TextWrapping.Wrap;
                    break;
                case TextWrapping.Wrap:
                    TextWrapping = TextWrapping.NoWrap;
                    break;
                default:
                    throw new NotImplementedException($"The following Text Wrap change logic does not implemented! {StatusBar.Visibility}");
            }

            await Task.CompletedTask;
        }
    }
}
