using System;
using System.Threading.Tasks;
using Application.Client.Dialogs.GoToLineDialog.Enums;
using Application.Client.Dialogs.GoToLineDialog.Interfaces;
using Application.Client.Dialogs.GoToLineDialog.Models;
using Application.Client.Infrastructure.Commands;
using Application.Client.Windows.Main.ViewModels;
using Application.Utilities.Extensions;

namespace Application.Client.Windows.Main.Commands.EditMenu
{
    internal class GoToLineCommand : AsyncCommandBase<MainWindowViewModel>
    {
        private readonly IGoToLineDialog _goToTheLineDialog;

        public GoToLineCommand(MainWindowViewModel callerViewModel, IGoToLineDialog goToTheLineDialog) : base(callerViewModel)
        {
            _goToTheLineDialog = goToTheLineDialog;
        }

        public override async Task ExecuteAsync()
        {
            GoToLineDialogResult dialogResult = await _goToTheLineDialog.ShowDialogAsync();

            if (dialogResult.GoToLineDialogResultType == GoToLineDialogResultType.GoToLine)
            {
                if (HasSelectedText(CallerViewModel.InputTextBoxViewModel.SelectedText))
                {
                    CallerViewModel.InputTextBoxViewModel.SelectionLength = default;
                }

                CallerViewModel.InputTextBoxViewModel.CaretIndex = GetSelectedLineStartIndex(CallerViewModel.InputTextBoxViewModel.Content, dialogResult.LineNumber);
            }
        }

        private static bool HasSelectedText(string selectedText)
        {
            return selectedText.Length != 0;
        }

        private static int GetSelectedLineStartIndex(string content, int lineNumber)
        {
            return content.IndexOfNth(Environment.NewLine, lineNumber - 1) + 1;
        }
    }
}
