﻿using System;
using System.Threading.Tasks;
using Application.Client.Common.Commands;
using Application.Client.Dialogs.ReplaceDialog.Windows.ViewModels;
using Application.Client.Messenger.GenericMessages.DialogMessages;
using FluentValidation;

namespace Application.Client.Dialogs.ReplaceDialog.Windows.Commands
{
    internal class ReplaceAllCommand : AsyncCommandBase<ReplaceWindowViewModel>
    {
        private readonly IValidator<ReplaceWindowViewModel> _validator;

        public ReplaceAllCommand(ReplaceWindowViewModel callerViewModel, IValidator<ReplaceWindowViewModel> validator) : base(callerViewModel)
        {
            _validator = validator;
        }

        public override async Task ExecuteAsync()
        {
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send(new ReplaceAllMessage(this));

            await Task.CompletedTask;
        }

        public override Predicate<object?> CanExecute => _ => _validator.Validate(CallerViewModel).IsValid;
    }
}
