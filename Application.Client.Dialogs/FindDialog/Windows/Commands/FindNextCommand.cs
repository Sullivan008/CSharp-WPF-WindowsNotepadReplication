using System;
using System.Threading.Tasks;
using Application.Client.Common.Commands;
using Application.Client.Dialogs.FindDialog.Windows.ViewModels;
using Application.Client.Messenger.GenericMessages.DialogMessages.Shared;
using FluentValidation;

namespace Application.Client.Dialogs.FindDialog.Windows.Commands
{
    internal class FindNextCommand : AsyncCommandBase<FindWindowViewModel>
    {
        private readonly IValidator<FindWindowViewModel> _validator;

        public FindNextCommand(FindWindowViewModel callerViewModel, IValidator<FindWindowViewModel> validator) : base(callerViewModel)
        {
            _validator = validator;
        }

        public override async Task ExecuteAsync()
        {
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send(new FindNextMessage(this));

            await Task.CompletedTask;
        }

        public override Predicate<object?> CanExecute => _ => _validator.Validate(CallerViewModel).IsValid;
    }
}
