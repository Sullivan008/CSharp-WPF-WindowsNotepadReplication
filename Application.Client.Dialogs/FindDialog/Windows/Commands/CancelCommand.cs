using System.Threading.Tasks;
using Application.Client.Dialogs.FindDialog.Windows.ViewModels;
using Application.Client.Infrastructure.Commands;

namespace Application.Client.Dialogs.FindDialog.Windows.Commands
{
    public class CancelCommand : AsyncCommandBase<FindWindowViewModel, FindWindow>
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
