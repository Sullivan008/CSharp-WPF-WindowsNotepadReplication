using System.Threading.Tasks;
using System.Windows.Input;
using Application.Client.Infrastructure.Commands;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ICommand _deleteTextCommand;
        public ICommand DeleteTextCommand => _deleteTextCommand ??= new RelayCommandAsync(DeleteTextCommandExecute, _ => CanExecuteDeleteTextCommand());

        private async Task DeleteTextCommandExecute()
        {
            InputTextBoxViewModel.SelectedText = string.Empty;

            await Task.CompletedTask;
        }

        private bool CanExecuteDeleteTextCommand()
        {
            return !string.IsNullOrWhiteSpace(InputTextBoxViewModel.SelectedText);
        }
    }
}
