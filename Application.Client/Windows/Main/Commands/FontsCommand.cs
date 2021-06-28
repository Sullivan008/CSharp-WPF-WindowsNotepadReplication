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
                    MediaFontSize = InputTextBoxViewModel.FontOptions.FontSize,
                    MediaFontStyle = InputTextBoxViewModel.FontOptions.FontStyle,
                    MediaFontWeight = InputTextBoxViewModel.FontOptions.FontWeight,
                    FontFamilyName = InputTextBoxViewModel.FontOptions.FontFamily.FamilyNames.Values.First()
                }
            };

            FontDialogResult dialogResult = await _fontDialog.ShowFontDialogAsync(fontDialogOptions);

            if (dialogResult.FontDialogResultType == FontDialogResultType.Ok)
            {
                InputTextBoxViewModel.FontOptions.FontFamily = dialogResult.FontResult.FontFamily;
                InputTextBoxViewModel.FontOptions.FontSize = dialogResult.FontResult.FontSize;
                InputTextBoxViewModel.FontOptions.FontStyle = dialogResult.FontResult.FontStyle;
                InputTextBoxViewModel.FontOptions.FontWeight = dialogResult.FontResult.FontWeight;
            }
        }
    }
}
