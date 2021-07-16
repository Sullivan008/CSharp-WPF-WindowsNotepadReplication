using System.Threading.Tasks;
using Application.Client.Dialogs.FindDialog.Interfaces;
using Application.Client.Infrastructure.Commands;
using Application.Client.Windows.Main.ViewModels;

namespace Application.Client.Windows.Main.Commands.EditMenu
{
    public class FindCommand : AsyncCommandBase<MainWindowViewModel>
    {
        private readonly IFindDialog _findDialog;

        public FindCommand(MainWindowViewModel callerViewModel, IFindDialog findDialog) : base(callerViewModel)
        {
            _findDialog = findDialog;
        }

        public override async Task ExecuteAsync()
        {
            await _findDialog.ShowAsync();
        }
    }
}
