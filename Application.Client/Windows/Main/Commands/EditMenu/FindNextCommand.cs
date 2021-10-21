﻿using System;
using System.Threading.Tasks;
using System.Windows;
using Application.Client.Common.Commands;
using Application.Client.Dialogs.MessageDialog.Interfaces;
using Application.Client.Dialogs.MessageDialog.Models;
using Application.Client.Services.FindNextAndReplaceConditions.Enums;
using Application.Client.Services.FindNextAndReplaceConditions.Interfaces;
using Application.Client.Windows.Main.ViewModels;

namespace Application.Client.Windows.Main.Commands.EditMenu
{
    internal class FindNextCommand : AsyncCommandBase<MainWindowViewModel>
    {
        private readonly IMessageDialog _messageDialog;

        private readonly IFindNextAndReplaceConditionsService _findNextSearchConditionsService;

        public FindNextCommand(MainWindowViewModel callerViewModel, IMessageDialog messageDialog, IFindNextAndReplaceConditionsService findNextSearchConditionsService) : base(callerViewModel)
        {
            _messageDialog = messageDialog;
            _findNextSearchConditionsService = findNextSearchConditionsService;
        }

        public override async Task ExecuteAsync()
        {
            int searchedTextStartIndex = GetSearchedTextStartIndex();

            if (searchedTextStartIndex == -1)
            {
                await _messageDialog.ShowDialogAsync(
                    new MessageDialogOptions { Title = "Notepad", Content = $"'{_findNextSearchConditionsService.FindWhat}' was not found!", Button = MessageBoxButton.OK, Icon = MessageBoxImage.Information });
            }
            else
            {
                CallerViewModel.InputTextBoxViewModel.CaretIndex = searchedTextStartIndex;
                CallerViewModel.InputTextBoxViewModel.SelectionLength = _findNextSearchConditionsService.FindWhat.Length;
            }

            CallerViewModel.WindowSettingsViewModel.Activated = true;

            await Task.CompletedTask;
        }

        public override Predicate<object?> CanExecute => _ => CallerViewModel.InputTextBoxViewModel.Content.Length != 0 &&
                                                              _findNextSearchConditionsService.HasSearchTerms;

        private int GetSearchedTextStartIndex()
        {
            return _findNextSearchConditionsService.DirectionType == DirectionType.Up
                ? GetNextTextStartIndex()
                : GetPreviousTextStartIndex();
        }

        private int GetNextTextStartIndex()
        {
            return Content.IndexOf(SearchedText, CallerViewModel.InputTextBoxViewModel.CaretIndex + CallerViewModel.InputTextBoxViewModel.SelectionLength,
                StringComparison.CurrentCulture);
        }

        private int GetPreviousTextStartIndex()
        {
            return Content.LastIndexOf(SearchedText, CallerViewModel.InputTextBoxViewModel.CaretIndex,
                StringComparison.CurrentCulture);
        }

        private string Content => _findNextSearchConditionsService.IsMatchCase
            ? CallerViewModel.InputTextBoxViewModel.Content
            : CallerViewModel.InputTextBoxViewModel.Content.ToLower();

        private string SearchedText => _findNextSearchConditionsService.IsMatchCase
            ? _findNextSearchConditionsService.FindWhat
            : _findNextSearchConditionsService.FindWhat.ToLower();
    }
}
