using System.Threading.Tasks;
using Application.Client.Common.Commands;

namespace Application.Client.Dialogs.AboutDialog.Windows.ViewModels.Commands
{
    internal class OkCommand : AsyncCommandBase<AboutWindowViewModel, AboutWindow>
    {
        public OkCommand(AboutWindowViewModel callerViewModel) : base(callerViewModel)
        { }

        public override async Task ExecuteAsync(AboutWindow window)
        {
            window.DialogResult = true;

            await Task.CompletedTask;
        }
    }
}
