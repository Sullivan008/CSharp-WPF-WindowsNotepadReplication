using System;
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

        private readonly IFindNextAndReplaceConditionsService _findNextAndReplaceConditionsService;

        public FindNextCommand(MainWindowViewModel callerViewModel, IMessageDialog messageDialog, IFindNextAndReplaceConditionsService findNextAndReplaceConditionsService) : base(callerViewModel)
        {
            _messageDialog = messageDialog;
            _findNextAndReplaceConditionsService = findNextAndReplaceConditionsService;
        }

        public override async Task ExecuteAsync()
        {
            int searchedTextStartIndex = GetSearchedTextStartIndex();

            if (searchedTextStartIndex == -1)
            {
                await _messageDialog.ShowDialogAsync(
                    new MessageDialogOptions { Title = "Notepad", Content = $"'{_findNextAndReplaceConditionsService.FindWhat}' was not found!", Button = MessageBoxButton.OK, Icon = MessageBoxImage.Information });
            }
            else
            {
                CallerViewModel.InputTextBoxViewModel.CaretIndex = searchedTextStartIndex;
                CallerViewModel.InputTextBoxViewModel.SelectionLength = _findNextAndReplaceConditionsService.FindWhat.Length;
            }

            CallerViewModel.WindowSettingsViewModel.Activated = true;

            await Task.CompletedTask;
        }

        public override Predicate<object?> CanExecute => _ => CallerViewModel.InputTextBoxViewModel.Content.Length != 0 &&
                                                              _findNextAndReplaceConditionsService.HasSearchTerms;

        private int GetSearchedTextStartIndex()
        {
            return _findNextAndReplaceConditionsService.DirectionType == DirectionType.Up
                ? GetNextTextStartIndex()
                : GetPreviousTextStartIndex();
        }

        private int GetNextTextStartIndex()
        {
            if (_findNextAndReplaceConditionsService.IsMatchCase)
            {
                return CallerViewModel.InputTextBoxViewModel.Content.IndexOf(_findNextAndReplaceConditionsService.FindWhat,
                                                                             CallerViewModel.InputTextBoxViewModel.CaretIndex + CallerViewModel.InputTextBoxViewModel.SelectionLength,
                                                                             StringComparison.CurrentCulture);
            }

            return CallerViewModel.InputTextBoxViewModel.Content.IndexOf(_findNextAndReplaceConditionsService.FindWhat,
                                                                         CallerViewModel.InputTextBoxViewModel.CaretIndex + CallerViewModel.InputTextBoxViewModel.SelectionLength,
                                                                         StringComparison.CurrentCultureIgnoreCase);
        }

        private int GetPreviousTextStartIndex()
        {
            if (_findNextAndReplaceConditionsService.IsMatchCase)
            {
                return CallerViewModel.InputTextBoxViewModel.Content.LastIndexOf(_findNextAndReplaceConditionsService.FindWhat,
                                                                                 CallerViewModel.InputTextBoxViewModel.CaretIndex,
                                                                                 StringComparison.CurrentCulture);
            }

            return CallerViewModel.InputTextBoxViewModel.Content.LastIndexOf(_findNextAndReplaceConditionsService.FindWhat,
                                                                             CallerViewModel.InputTextBoxViewModel.CaretIndex,
                                                                             StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
