using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.Client.Infrastructure.Commands;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ICommand _putDateTimeTextCommand;
        public ICommand PutDateTimeTextCommand => _putDateTimeTextCommand ??= new RelayCommandAsync(PutDateTimeTextCommandExecute);

        private async Task PutDateTimeTextCommandExecute()
        {
            int oldCaretIndexValue = InputTextBoxViewModel.CaretIndex;
            string dateTimeValue = DateTime.Now.ToString("MM-dd-yyyy hh:mm tt", new CultureInfo("en-EN"));

            InputTextBoxViewModel.Content = InputTextBoxViewModel.Content.Insert(InputTextBoxViewModel.CaretIndex, dateTimeValue);
            InputTextBoxViewModel.CaretIndex = oldCaretIndexValue + dateTimeValue.Length;

            await Task.CompletedTask;
        }
    }
}
