using System.Threading.Tasks;
using Application.Client.Common.Commands;
using Application.Client.Dialogs.FindDialog.Services.Interfaces;
using Application.Client.Dialogs.FindDialog.Windows.ViewModels;

namespace Application.Client.Dialogs.FindDialog.Windows.Commands.Shared
{
    internal class LoadDialogSettingsFromCache : AsyncCommandBase<FindWindowViewModel>
    {
        private readonly IFindDialogSettingsService _findDialogSettingsService;

        public LoadDialogSettingsFromCache(FindWindowViewModel callerViewModel, IFindDialogSettingsService findDialogSettingsService) : base(callerViewModel)
        {
            _findDialogSettingsService = findDialogSettingsService;
        }

        public override async Task ExecuteAsync()
        {
            CallerViewModel.FindWhat = _findDialogSettingsService.FindWhat;
            CallerViewModel.IsMatchCase = _findDialogSettingsService.IsMatchCase;
            CallerViewModel.DirectionType = _findDialogSettingsService.DirectionType;

            await Task.CompletedTask;
        }
    }
}
