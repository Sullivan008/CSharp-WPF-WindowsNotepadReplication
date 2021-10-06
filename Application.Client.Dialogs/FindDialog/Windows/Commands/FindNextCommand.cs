using System;
using System.Threading.Tasks;
using Application.Client.Dialogs.FindDialog.Services.Interfaces;
using Application.Client.Dialogs.FindDialog.Windows.ViewModels;
using Application.Client.Infrastructure.Commands;
using FluentValidation;

namespace Application.Client.Dialogs.FindDialog.Windows.Commands
{
    internal class FindNextCommand : AsyncCommandBase<FindWindowViewModel>
    {
        private readonly IValidator<FindWindowViewModel> _validator;

        private readonly IFindDialogSettingsService _findDialogSettingsService;

        public FindNextCommand(FindWindowViewModel callerViewModel, IValidator<FindWindowViewModel> validator, IFindDialogSettingsService findDialogSettingsService) : base(callerViewModel)
        {
            _validator = validator;
            _findDialogSettingsService = findDialogSettingsService;
        }

        public override async Task ExecuteAsync()
        {
            SetSearchTermsIntoCache();

            OnFindNext();

            await Task.CompletedTask;
        }

        public override Predicate<object> CanExecute => _ => _validator.Validate(CallerViewModel).IsValid;

        private void SetSearchTermsIntoCache()
        {
            _findDialogSettingsService.SetFindWhat(CallerViewModel.FindWhat);
            _findDialogSettingsService.SetIsMatchCase(CallerViewModel.IsMatchCase);
            _findDialogSettingsService.SetDirectionType((Cache.DataModels.FindDialog.Enums.DirectionType)CallerViewModel.DirectionType);
        }

        private void OnFindNext(EventArgs eventArgs = null)
        {
            if (CallerViewModel.OnFindNextEvent == null)
            {
                throw new ArgumentNullException(nameof(CallerViewModel.OnFindNextEvent), "The value cannot be null!");
            }

            CallerViewModel.OnFindNextEvent(this, eventArgs ?? EventArgs.Empty);
        }
    }
}
