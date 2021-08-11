using System;
using System.Threading.Tasks;
using System.Windows;
using Application.Client.Infrastructure.Commands;
using Application.Client.Windows.Main.ViewModels;

namespace Application.Client.Windows.Main.Commands.FormatMenu
{
    public class ChangeTextWrappingCommand : AsyncCommandBase<MainWindowViewModel>
    { 
        public ChangeTextWrappingCommand(MainWindowViewModel callerViewModel) : base(callerViewModel)
        { }

        public override async Task ExecuteAsync()
        {
            switch (CallerViewModel.InputTextBoxViewModel.TextWrapping)
            {
                case TextWrapping.NoWrap:
                    CallerViewModel.InputTextBoxViewModel.TextWrapping = TextWrapping.Wrap;
                    break;
                case TextWrapping.Wrap:
                    CallerViewModel.InputTextBoxViewModel.TextWrapping = TextWrapping.NoWrap;
                    break;
                default:
                    throw new NotImplementedException($"The following Text Wrap change logic does not implemented! {CallerViewModel.InputTextBoxViewModel.TextWrapping}");
            }

            await Task.CompletedTask;
        }
    }
}
