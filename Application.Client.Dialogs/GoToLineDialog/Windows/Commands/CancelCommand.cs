using System.Threading.Tasks;
using Application.Client.Common.Commands;
using Application.Client.Dialogs.GoToLineDialog.Windows.ViewModels;

namespace Application.Client.Dialogs.GoToLineDialog.Windows.Commands
{
    internal class CancelCommand : AsyncCommandBase<GoToLineWindowViewModel, GoToLineWindow>
    {
        public CancelCommand(GoToLineWindowViewModel callerViewModel) : base(callerViewModel)
        { }

        public override async Task ExecuteAsync(GoToLineWindow window)
        {
            window.DialogResult = false;

            await Task.CompletedTask;
        }
    }
}
