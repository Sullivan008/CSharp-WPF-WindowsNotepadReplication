using System.Threading.Tasks;
using Application.Client.Common.Commands;
using Application.Client.Dialogs.ReplaceDialog.Services.Interfaces;
using Application.Client.Dialogs.ReplaceDialog.Windows.ViewModels;

namespace Application.Client.Dialogs.ReplaceDialog.Windows.Commands.Shared
{
    internal class LoadDialogSettingsFromCache : AsyncCommandBase<ReplaceWindowViewModel>
    {
        private readonly IReplaceDialogSettingsService _replaceDialogSettingsService;

        public LoadDialogSettingsFromCache(ReplaceWindowViewModel callerViewModel, IReplaceDialogSettingsService replaceDialogSettingsService) : base(callerViewModel)
        {
            _replaceDialogSettingsService = replaceDialogSettingsService;
        }

        public override async Task ExecuteAsync()
        {
            CallerViewModel.FindWhat = _replaceDialogSettingsService.FindWhat;
            CallerViewModel.ReplaceWith = _replaceDialogSettingsService.ReplaceWith;
            CallerViewModel.IsMatchCase = _replaceDialogSettingsService.IsMatchCase;

            await Task.CompletedTask;
        }
    }
}
