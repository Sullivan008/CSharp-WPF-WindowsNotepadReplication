using System.Threading.Tasks;
using Application.Client.Common.Commands;
using Application.Client.Dialogs.FindDialog.Windows.ViewModels;

namespace Application.Client.Dialogs.FindDialog.Windows.Commands
{
    internal class CancelCommand : AsyncCommandBase<FindWindowViewModel, FindWindow>
    {
        public CancelCommand(FindWindowViewModel callerViewModel) : base(callerViewModel)
        { }

        public override async Task ExecuteAsync(FindWindow window)
        {
            window.Close();

            await Task.CompletedTask;
        }
    }
}
