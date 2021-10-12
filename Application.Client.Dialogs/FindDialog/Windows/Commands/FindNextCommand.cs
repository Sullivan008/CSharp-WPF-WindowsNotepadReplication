using System;
using System.Threading.Tasks;
using Application.Client.Common.Commands;
using Application.Client.Dialogs.FindDialog.Services.Interfaces;
using Application.Client.Dialogs.FindDialog.Windows.ViewModels;
using Application.Client.Messenger.GenericMessages.DialogMessages;
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

            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send(new FindNextMessage(this));

            await Task.CompletedTask;
        }

        public override Predicate<object?> CanExecute => _ => _validator.Validate(CallerViewModel).IsValid;

        private void SetSearchTermsIntoCache()
        {
            _findDialogSettingsService.SetFindWhat(CallerViewModel.FindWhat);
            _findDialogSettingsService.SetIsMatchCase(CallerViewModel.IsMatchCase);
            _findDialogSettingsService.SetDirectionType((Cache.DataModels.FindDialog.Enums.DirectionType)CallerViewModel.DirectionType);
        }
    }
}
