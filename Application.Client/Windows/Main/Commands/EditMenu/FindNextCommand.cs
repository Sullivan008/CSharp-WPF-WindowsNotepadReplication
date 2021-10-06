using System;
using System.Threading.Tasks;
using System.Windows;
using Application.Client.Dialogs.MessageDialog.Interfaces;
using Application.Client.Dialogs.MessageDialog.Models;
using Application.Client.Infrastructure.Commands;
using Application.Client.Services.FindDialogSearchTerms.Enums;
using Application.Client.Services.FindDialogSearchTerms.Interfaces;
using Application.Client.Windows.Main.ViewModels;

namespace Application.Client.Windows.Main.Commands.EditMenu
{
    public class FindNextCommand : AsyncCommandBase<MainWindowViewModel>
    {
        private readonly IMessageDialog _messageDialog;

        private readonly IFindDialogSearchTermsService _findDialogSearchTermsService;

        public FindNextCommand(MainWindowViewModel callerViewModel, IMessageDialog messageDialog, IFindDialogSearchTermsService findDialogSearchTermsService) : base(callerViewModel)
        {
            _messageDialog = messageDialog;
            _findDialogSearchTermsService = findDialogSearchTermsService;
        }

        public override async Task ExecuteAsync()
        {
            int searchedTextStartIndex = GetSearchedTextStartIndex();

            if (searchedTextStartIndex == -1)
            {
                await _messageDialog.ShowDialogAsync(
                    new MessageDialogOptions { Title = "Notepad", Content = $"'{_findDialogSearchTermsService.Text}' was not found!", Button = MessageBoxButton.OK, Icon = MessageBoxImage.Information });
            }
            else
            {
                CallerViewModel.InputTextBoxViewModel.CaretIndex = searchedTextStartIndex;
                CallerViewModel.InputTextBoxViewModel.SelectionLength = _findDialogSearchTermsService.Text.Length;
            }

            CallerViewModel.WindowSettingsViewModel.Activated = true;

            await Task.CompletedTask;
        }

        public override Predicate<object> CanExecute => _ => _findDialogSearchTermsService.HasSearchTerms;

        private int GetSearchedTextStartIndex()
        {
            return _findDialogSearchTermsService.DirectionType == DirectionType.Up
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

        private string Content => _findDialogSearchTermsService.IsMatchCase
            ? CallerViewModel.InputTextBoxViewModel.Content
            : CallerViewModel.InputTextBoxViewModel.Content.ToLower();

        private string SearchedText => _findDialogSearchTermsService.IsMatchCase
            ? _findDialogSearchTermsService.Text
            : _findDialogSearchTermsService.Text.ToLower();
    }
}
