using System;
using System.Threading.Tasks;
using Application.Client.Common.Commands;
using Application.Client.Dialogs.ReplaceDialog.Windows.ViewModels;

namespace Application.Client.Dialogs.ReplaceDialog.Windows.Commands
{
    internal class FindNextCommand : AsyncCommandBase<ReplaceWindowViewModel>
    {
        public FindNextCommand(ReplaceWindowViewModel callerViewModel) : base(callerViewModel)
        { }

        public override Task ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
