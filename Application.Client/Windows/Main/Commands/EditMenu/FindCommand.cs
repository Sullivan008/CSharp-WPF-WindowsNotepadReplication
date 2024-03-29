﻿using System;
using System.Threading.Tasks;
using Application.Client.Common.Commands;
using Application.Client.Dialogs.FindDialog.Interfaces;
using Application.Client.Windows.Main.ViewModels;

namespace Application.Client.Windows.Main.Commands.EditMenu
{
    internal class FindCommand : AsyncCommandBase<MainWindowViewModel>
    {
        private readonly IFindDialog _findDialog;

        public FindCommand(MainWindowViewModel callerViewModel, IFindDialog findDialog) : base(callerViewModel)
        {
            _findDialog = findDialog;
        }

        public override async Task ExecuteAsync()
        {
            await _findDialog.ShowAsync();
        }

        public override Predicate<object?> CanExecute => _ => CallerViewModel.InputTextBoxViewModel.Content.Length != 0;
    }
}
