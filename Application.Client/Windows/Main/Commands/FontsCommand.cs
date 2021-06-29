using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.Client.Dialogs.FontDialog.Enums;
using Application.Client.Dialogs.FontDialog.Models.Options;
using Application.Client.Dialogs.FontDialog.Models.Result;
using Application.Client.Infrastructure.Commands;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ICommand _fontsCommand;
        public ICommand FontsCommand => _fontsCommand ??= new RelayCommandAsync(FontsCommandExecute);

        private async Task FontsCommandExecute()
        {
            FontDialogOptions fontDialogOptions = new()
            {
                FontOptions = new FontOptions
                {
                    MediaFontSize = InputTextBox.FontOptions.FontSize,
                    MediaFontStyle = InputTextBox.FontOptions.FontStyle,
                    MediaFontWeight = InputTextBox.FontOptions.FontWeight,
                    FontFamilyName = InputTextBox.FontOptions.FontFamily.FamilyNames.Values.First()
                }
            };

            FontDialogResult dialogResult = await _fontDialog.ShowFontDialogAsync(fontDialogOptions);

            if (dialogResult.FontDialogResultType == FontDialogResultType.Ok)
            {
                InputTextBox.FontOptions.FontFamily = dialogResult.FontResult.FontFamily;
                InputTextBox.FontOptions.FontSize = dialogResult.FontResult.FontSize;
                InputTextBox.FontOptions.FontStyle = dialogResult.FontResult.FontStyle;
                InputTextBox.FontOptions.FontWeight = dialogResult.FontResult.FontWeight;
            }
        }
    }
}
