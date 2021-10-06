using System;
using System.Threading.Tasks;
using System.Windows;
using Application.Client.Common.Commands;
using Application.Client.Windows.Main.ViewModels;

namespace Application.Client.Windows.Main.Commands.FormatMenu
{
    internal class ChangeTextWrappingCommand : AsyncCommandBase<MainWindowViewModel>
    { 
        public ChangeTextWrappingCommand(MainWindowViewModel callerViewModel) : base(callerViewModel)
        { }

        public override async Task ExecuteAsync()
        {
            CallerViewModel.InputTextBoxViewModel.TextWrapping = CallerViewModel.InputTextBoxViewModel.TextWrapping switch
            {
                TextWrapping.NoWrap => TextWrapping.Wrap,
                TextWrapping.Wrap => TextWrapping.NoWrap,
                _ => throw new NotImplementedException($"The following Text Wrap change logic does not implemented! {CallerViewModel.InputTextBoxViewModel.TextWrapping}"),
            };

            await Task.CompletedTask;
        }
    }
}
