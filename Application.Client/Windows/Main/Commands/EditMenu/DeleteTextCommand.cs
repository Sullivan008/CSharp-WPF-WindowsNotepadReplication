using System;
using System.Threading.Tasks;
using Application.Client.Infrastructure.Commands;
using Application.Client.Windows.Main.ViewModels;

namespace Application.Client.Windows.Main.Commands.EditMenu
{
    internal class DeleteTextCommand : AsyncCommandBase<MainWindowViewModel>
    {
        public DeleteTextCommand(MainWindowViewModel callerViewModel) : base(callerViewModel)
        { }

        public override async Task ExecuteAsync()
        {
            CallerViewModel.InputTextBoxViewModel.SelectedText = string.Empty;

            await Task.CompletedTask;
        }

        public override Predicate<object> CanExecute => _ => !string.IsNullOrWhiteSpace(CallerViewModel.InputTextBoxViewModel.SelectedText);
    }
}
