using System;
using System.Globalization;
using System.Threading.Tasks;
using Application.Client.Infrastructure.Commands;
using Application.Client.Windows.Main.ViewModels;

namespace Application.Client.Windows.Main.Commands.EditMenu
{
    internal class PutDateTimeTextCommand : AsyncCommandBase<MainWindowViewModel>
    {
        public PutDateTimeTextCommand(MainWindowViewModel callerViewModel) : base(callerViewModel)
        { }

        public override async Task ExecuteAsync()
        {
            int originalCaretIndex = OriginalCaretIndex;
            string currentDateTimeValue = CurrentDateTimeAsString;

            CallerViewModel.InputTextBoxViewModel.Content = CallerViewModel.InputTextBoxViewModel.Content.Insert(originalCaretIndex, currentDateTimeValue);
            CallerViewModel.InputTextBoxViewModel.CaretIndex = CalculateNewCaretIndex(originalCaretIndex, currentDateTimeValue);

            await Task.CompletedTask;
        }

        private static int CalculateNewCaretIndex(int originalCaretIndex, string insertedString)
        {
            return originalCaretIndex + insertedString.Length;
        }

        private int OriginalCaretIndex => CallerViewModel.InputTextBoxViewModel.CaretIndex;

        private static string CurrentDateTimeAsString =>
            DateTime.Now.ToString("MM-dd-yyyy hh:mm tt", new CultureInfo("en-EN"));
    }
}
