using System;
using System.Globalization;
using System.Threading.Tasks;
using Application.Client.Infrastructure.Commands;
using Application.Client.Windows.Main.ViewModels;

namespace Application.Client.Windows.Main.Commands.EditMenu
{
    public class PutDateTimeTextCommand : AsyncCommandBase<MainWindowViewModel>
    {
        public PutDateTimeTextCommand(MainWindowViewModel callerViewModel) : base(callerViewModel)
        { }

        public override async Task ExecuteAsync()
        {
            int originalCaretIndex = GetOriginalCaretIndex();
            string currentDateTimeValue = GetCurrentDateTimeAsString();

            CallerViewModel.InputTextBox.Content = CallerViewModel.InputTextBox.Content.Insert(originalCaretIndex, currentDateTimeValue);
            CallerViewModel.InputTextBox.CaretIndex = CalculateNewCaretIndex(originalCaretIndex, currentDateTimeValue);

            await Task.CompletedTask;
        }

        private int GetOriginalCaretIndex()
        {
            return CallerViewModel.InputTextBox.CaretIndex;
        }

        private int CalculateNewCaretIndex(int originalCaretIndex, string insertedString)
        {
            return originalCaretIndex + insertedString.Length;
        }

        private string GetCurrentDateTimeAsString()
        {
            return DateTime.Now.ToString("MM-dd-yyyy hh:mm tt", new CultureInfo("en-EN"));
        }
    }
}
