using System;
using System.Threading.Tasks;
using System.Windows;
using Application.Client.Common.Commands;
using Application.Client.Dialogs.MessageDialog.Interfaces;
using Application.Client.Dialogs.MessageDialog.Models;
using Application.Client.Services.FindNextAndReplaceConditions.Interfaces;
using Application.Client.Windows.Main.ViewModels;

namespace Application.Client.Windows.Main.Commands.EditMenu
{
    internal class ReplaceNextCommand : AsyncCommandBase<MainWindowViewModel>
    {
        private readonly IMessageDialog _messageDialog;

        private readonly IFindNextAndReplaceConditionsService _findNextAndReplaceConditionsService;

        public ReplaceNextCommand(MainWindowViewModel callerViewModel, IMessageDialog messageDialog, IFindNextAndReplaceConditionsService findNextAndReplaceConditionsService) : base(callerViewModel)
        {
            _messageDialog = messageDialog;
            _findNextAndReplaceConditionsService = findNextAndReplaceConditionsService;
        }

        public override async Task ExecuteAsync()
        {
            if (HasSelectedText)
            {
                SelectedTextReplace();
            }

            FindNextTextToReplace();

            await Task.CompletedTask;
        }

        public override Predicate<object?> CanExecute => _ => CallerViewModel.InputTextBoxViewModel.Content.Length != 0 &&
                                                              _findNextAndReplaceConditionsService.HasSearchTerms;

        private bool HasSelectedText => CallerViewModel.InputTextBoxViewModel.SelectionLength != 0;

        private void SelectedTextReplace()
        {
            if (_findNextAndReplaceConditionsService.IsMatchCase && CallerViewModel.InputTextBoxViewModel.SelectedText.Equals(_findNextAndReplaceConditionsService.FindWhat, StringComparison.CurrentCulture) ||
                !_findNextAndReplaceConditionsService.IsMatchCase && CallerViewModel.InputTextBoxViewModel.SelectedText.Equals(_findNextAndReplaceConditionsService.FindWhat, StringComparison.CurrentCultureIgnoreCase))
            {
                CallerViewModel.InputTextBoxViewModel.SelectedText = _findNextAndReplaceConditionsService.ReplaceWith;

                CallerViewModel.InputTextBoxViewModel.SelectionLength = 0;
                CallerViewModel.InputTextBoxViewModel.CaretIndex += _findNextAndReplaceConditionsService.ReplaceWith.Length;
            }
        }

        private async void FindNextTextToReplace()
        {
            int searchedTextStartIndex = GetNextSearchedTextStartIndex();

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
        }

        private int GetNextSearchedTextStartIndex()
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
    }
}
