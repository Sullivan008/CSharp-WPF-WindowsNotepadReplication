using System;
using System.Threading.Tasks;
using Application.Client.Common.Commands;
using Application.Client.Dialogs.ReplaceDialog.Windows.ViewModels;

namespace Application.Client.Dialogs.ReplaceDialog.Windows.Commands
{
    internal class CancelCommand : AsyncCommandBase<ReplaceWindowViewModel, ReplaceWindow>
    {
        public CancelCommand(ReplaceWindowViewModel callerViewModel) : base(callerViewModel)
        { }

        public override Task ExecuteAsync(ReplaceWindow parameter)
        {
            throw new NotImplementedException();
        }
    }
}
