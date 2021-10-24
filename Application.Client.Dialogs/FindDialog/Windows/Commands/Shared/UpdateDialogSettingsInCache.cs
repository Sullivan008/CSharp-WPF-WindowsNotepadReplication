using System.Threading.Tasks;
using Application.Client.Common.Commands;
using Application.Client.Dialogs.FindDialog.Services.Interfaces;
using Application.Client.Dialogs.FindDialog.Windows.ViewModels;

namespace Application.Client.Dialogs.FindDialog.Windows.Commands.Shared
{
    internal class UpdateDialogSettingsInCache : AsyncCommandBase<FindWindowViewModel>
    {
        private readonly IFindDialogSettingsService _findDialogSettingsService;

        public UpdateDialogSettingsInCache(FindWindowViewModel callerViewModel, IFindDialogSettingsService findDialogSettingsService) : base(callerViewModel)
        {
            _findDialogSettingsService = findDialogSettingsService;
        }

        public override async Task ExecuteAsync()
        {
            _findDialogSettingsService.SetFindWhat(CallerViewModel.FindWhat);
            _findDialogSettingsService.SetIsMatchCase(CallerViewModel.IsMatchCase);
            _findDialogSettingsService.SetDirectionType(CallerViewModel.DirectionType);

            await Task.CompletedTask;
        }
    }
}
