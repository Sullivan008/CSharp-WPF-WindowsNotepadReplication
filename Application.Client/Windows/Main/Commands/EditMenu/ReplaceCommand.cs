using System;
using System.Threading.Tasks;
using Application.Client.Common.Commands;
using Application.Client.Dialogs.ReplaceDialog.Interfaces;
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

        public override Predicate<object?> CanExecute => _ => CallerViewModel.InputTextBoxViewModel.Content.Length != 0;
    }
}
