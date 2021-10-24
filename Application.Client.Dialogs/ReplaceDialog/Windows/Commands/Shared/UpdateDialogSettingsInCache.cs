using System.Threading.Tasks;
using Application.Client.Common.Commands;
using Application.Client.Dialogs.ReplaceDialog.Services.Interfaces;
using Application.Client.Dialogs.ReplaceDialog.Windows.ViewModels;

namespace Application.Client.Dialogs.ReplaceDialog.Windows.Commands.Shared
{
    internal class UpdateDialogSettingsInCache : AsyncCommandBase<ReplaceWindowViewModel>
    {
        private readonly IReplaceDialogSettingsService _replaceDialogSettingsService;

        public UpdateDialogSettingsInCache(ReplaceWindowViewModel callerViewModel, IReplaceDialogSettingsService replaceDialogSettingsService) : base(callerViewModel)
        {
            _replaceDialogSettingsService = replaceDialogSettingsService;
        }

        public override async Task ExecuteAsync()
        {
            _replaceDialogSettingsService.SetDirectionTypeToDefaultValue();
            _replaceDialogSettingsService.SetFindWhat(CallerViewModel.FindWhat);
            _replaceDialogSettingsService.SetReplaceWith(CallerViewModel.ReplaceWith);
            _replaceDialogSettingsService.SetIsMatchCase(CallerViewModel.IsMatchCase);

            await Task.CompletedTask;
        }
    }
}
