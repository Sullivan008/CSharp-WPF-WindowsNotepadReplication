using System.Threading.Tasks;
using Application.Client.Dialogs.ReplaceDialog.Interfaces;
using Application.Client.Infrastructure.Commands;
using Application.Client.Windows.Main.ViewModels;

namespace Application.Client.Windows.Main.Commands.EditMenu
{
    internal class ReplaceCommand : AsyncCommandBase<MainWindowViewModel>
    {
        private readonly IReplaceDialog _replaceDialog;

        public ReplaceCommand(MainWindowViewModel callerViewModel, IReplaceDialog replaceDialog) : base(callerViewModel)
        {
            _replaceDialog = replaceDialog;
        }

        public override async Task ExecuteAsync()
        {
            await _replaceDialog.ShowAsync();
        }
    }
}
