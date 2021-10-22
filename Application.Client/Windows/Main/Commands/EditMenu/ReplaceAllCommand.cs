using System;
using System.Threading.Tasks;
using Application.Client.Common.Commands;
using Application.Client.Services.FindNextAndReplaceConditions.Interfaces;
using Application.Client.Windows.Main.ViewModels;

namespace Application.Client.Windows.Main.Commands.EditMenu
{
    internal class ReplaceAllCommand : AsyncCommandBase<MainWindowViewModel>
    {
        private readonly IFindNextAndReplaceConditionsService _findNextAndReplaceConditionsService;

        public ReplaceAllCommand(MainWindowViewModel callerViewModel, IFindNextAndReplaceConditionsService findNextAndReplaceConditionsService) : base(callerViewModel)
        {
            _findNextAndReplaceConditionsService = findNextAndReplaceConditionsService;
        }

        public override async Task ExecuteAsync()
        {
            CallerViewModel.InputTextBoxViewModel.SelectionLength = 0;

            if (_findNextAndReplaceConditionsService.IsMatchCase)
            {
                CallerViewModel.InputTextBoxViewModel.Content = CallerViewModel.InputTextBoxViewModel.Content
                    .Replace(_findNextAndReplaceConditionsService.FindWhat, _findNextAndReplaceConditionsService.ReplaceWith, StringComparison.CurrentCulture);
            }
            else
            {
                CallerViewModel.InputTextBoxViewModel.Content = CallerViewModel.InputTextBoxViewModel.Content
                    .Replace(_findNextAndReplaceConditionsService.FindWhat, _findNextAndReplaceConditionsService.ReplaceWith, StringComparison.CurrentCultureIgnoreCase);
            }


            await Task.CompletedTask;
        }
    }
}
