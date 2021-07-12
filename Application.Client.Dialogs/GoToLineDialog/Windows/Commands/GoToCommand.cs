using System;
using System.Threading.Tasks;
using System.Windows;
using Application.Client.Dialogs.GoToLineDialog.Windows.ViewModels;
using Application.Client.Dialogs.MessageDialog.Interfaces;
using Application.Client.Dialogs.MessageDialog.Models;
using Application.Client.Infrastructure.Commands;
using Application.Client.Services.Interfaces;
using FluentValidation;

namespace Application.Client.Dialogs.GoToLineDialog.Windows.Commands
{
    public class GoToCommand : AsyncCommandBase<GoToLineWindowViewModel, GoToLineWindow>
    {
        private readonly IMessageDialog _messageDialog;

        private readonly IDocInfoService _docInfoService;

        private readonly IValidator<GoToLineWindowViewModel> _validator;

        public GoToCommand(GoToLineWindowViewModel callerViewModel, IValidator<GoToLineWindowViewModel> validator, IMessageDialog messageDialog, IDocInfoService docInfoService) : base(callerViewModel)
        {
            _validator = validator;
            _messageDialog = messageDialog;
            _docInfoService = docInfoService;
        }

        public override async Task ExecuteAsync(GoToLineWindow window)
        {
            if (IsLineNumberGreaterThanLines(CallerViewModel.LineNumber.Value, _docInfoService.ContentLines))
            {
                MessageDialogOptions dialogOptions = new() { Content = "The line number exceeds the total line number", Title = window.Title, Button = MessageBoxButton.OK, Icon = MessageBoxImage.Warning };
                await _messageDialog.ShowMessageDialogAsync(dialogOptions);

                return;
            } 

            window.DialogResult = true;
        }

        private static bool IsLineNumberGreaterThanLines(int lineNumber, int lines)
        {
            return lineNumber > lines;
        }

        public override Predicate<object> CanExecute => _ => _validator.Validate(CallerViewModel).IsValid;
    }
}
