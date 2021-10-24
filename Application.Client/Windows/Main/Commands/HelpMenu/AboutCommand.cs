using System.Threading.Tasks;
using Application.Client.Common.Commands;
using Application.Client.Dialogs.AboutDialog.Interfaces;
using Application.Client.Windows.Main.ViewModels;

namespace Application.Client.Windows.Main.Commands.HelpMenu
{
    public class AboutCommand : AsyncCommandBase<MainWindowViewModel>
    {
        private readonly IAboutDialog _aboutDialog;

        public AboutCommand(MainWindowViewModel callerViewModel, IAboutDialog aboutDialog) : base(callerViewModel)
        {
            _aboutDialog = aboutDialog;
        }

        public override async Task ExecuteAsync()
        {
            await _aboutDialog.ShowDialogAsync();
        }
    }
}
