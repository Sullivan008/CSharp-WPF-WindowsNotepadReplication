using System;
using System.Threading.Tasks;
using Application.Client.Cache.DataModels.FindNext.SearchConditions.Enums;
using Application.Client.Common.Commands;
using Application.Client.Dialogs.ReplaceDialog.Services.Interfaces;
using Application.Client.Dialogs.ReplaceDialog.Windows.ViewModels;
using Application.Client.Messenger.GenericMessages.DialogMessages;
using FluentValidation;

namespace Application.Client.Dialogs.ReplaceDialog.Windows.Commands
{
    internal class FindNextCommand : AsyncCommandBase<ReplaceWindowViewModel>
    {
        private readonly IValidator<ReplaceWindowViewModel> _validator;

        private readonly IReplaceDialogSettingsService _replaceDialogSettingsService;

        public FindNextCommand(ReplaceWindowViewModel callerViewModel, IValidator<ReplaceWindowViewModel> validator, IReplaceDialogSettingsService replaceDialogSettingsService) : base(callerViewModel)
        {
            _validator = validator;
            _replaceDialogSettingsService = replaceDialogSettingsService;
        }

        public override async Task ExecuteAsync()
        {
            RefreshReplaceDialogSettingsCache();

            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send(new FindNextMessage(this));

            await Task.CompletedTask;
        }

        public override Predicate<object?> CanExecute => _ => _validator.Validate(CallerViewModel).IsValid;

        private void RefreshReplaceDialogSettingsCache()
        {
            _replaceDialogSettingsService.SetDirectionType(DirectionType.Up);
            _replaceDialogSettingsService.SetFindWhat(CallerViewModel.FindWhat);
            _replaceDialogSettingsService.SetReplaceWith(CallerViewModel.ReplaceWith);
            _replaceDialogSettingsService.SetIsMatchCase(CallerViewModel.IsMatchCase);
        }
    }
}
