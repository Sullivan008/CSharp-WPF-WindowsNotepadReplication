using System;
using System.Threading.Tasks;
using System.Windows;
using Application.Client.Dialogs.MessageDialog.Interfaces;
using Application.Client.Dialogs.MessageDialog.Models;
using Application.Client.Infrastructure.Commands;
using Application.Client.Services.SearchTerms.Enums;
using Application.Client.Services.SearchTerms.Interfaces;
using Application.Client.Windows.Main.ViewModels;

namespace Application.Client.Windows.Main.Commands.EditMenu
{
    public class FindNextCommand : AsyncCommandBase<MainWindowViewModel>
    {
        private readonly IMessageDialog _messageDialog;

        private readonly ISearchTermsService _searchTermsService;

        public FindNextCommand(MainWindowViewModel callerViewModel, IMessageDialog messageDialog, ISearchTermsService searchTermsService) : base(callerViewModel)
        {
            _messageDialog = messageDialog;
            _searchTermsService = searchTermsService;
        }

        public override async Task ExecuteAsync()
        {
            int searchedTextStartIndex = GetSearchedTextStartIndex();

            if (searchedTextStartIndex == -1)
            {
                await _messageDialog.ShowMessageDialogAsync(
                    new MessageDialogOptions { Title = "Notepad", Content = $"'{_searchTermsService.Text}' was not found!", Button = MessageBoxButton.OK, Icon = MessageBoxImage.Information });
            }
            else
            {
                CallerViewModel.InputTextBox.CaretIndex = searchedTextStartIndex;
                CallerViewModel.InputTextBox.SelectionLength = _searchTermsService.Text.Length;
            }

            CallerViewModel.WindowSettings.Activated = true;

            await Task.CompletedTask;
        }

        public override Predicate<object> CanExecute => _ => _searchTermsService.HasSearchTerms();

        private int GetSearchedTextStartIndex()
        {
            return _searchTermsService.DirectionType == DirectionType.Up
                ? GetNextTextStartIndex()
                : GetPreviousTextStartIndex();
        }

        private int GetNextTextStartIndex()
        {
            return Content.IndexOf(SearchedText, CallerViewModel.InputTextBox.CaretIndex + CallerViewModel.InputTextBox.SelectionLength,
                StringComparison.CurrentCulture);
        }

        private int GetPreviousTextStartIndex()
        {
            return Content.LastIndexOf(SearchedText, CallerViewModel.InputTextBox.CaretIndex,
                StringComparison.CurrentCulture);
        }

        private string Content => _searchTermsService.IsMatchCase
            ? CallerViewModel.InputTextBox.Content
            : CallerViewModel.InputTextBox.Content.ToLower();

        private string SearchedText => _searchTermsService.IsMatchCase
            ? _searchTermsService.Text
            : _searchTermsService.Text.ToLower();
    }
}
