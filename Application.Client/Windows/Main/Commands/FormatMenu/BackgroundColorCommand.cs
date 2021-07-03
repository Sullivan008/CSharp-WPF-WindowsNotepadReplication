using System.Threading.Tasks;
using System.Windows.Media;
using Application.Client.Dialogs.ColorDialog.Enums;
using Application.Client.Dialogs.ColorDialog.Interfaces;
using Application.Client.Dialogs.ColorDialog.Models;
using Application.Client.Infrastructure.Commands;
using Application.Client.Windows.Main.ViewModels;

namespace Application.Client.Windows.Main.Commands.FormatMenu
{
    public class BackgroundColorCommand : AsyncCommandBase<MainWindowViewModel>
    {
        private readonly IColorDialog _colorDialog;

        public BackgroundColorCommand(MainWindowViewModel callerViewModel, IColorDialog colorDialog) : base(callerViewModel)
        {
            _colorDialog = colorDialog;
        }

        public override async Task ExecuteAsync()
        {
            ColorDialogResult dialogResult = await _colorDialog.ShowColorDialogAsync(new ColorDialogOptions());

            if (dialogResult.ColorDialogResultType == ColorDialogResultType.Ok)
            {
                CallerViewModel.InputTextBox.Background = ConvertToSolidColorBrush(dialogResult.Color);
            }
        }

        private static SolidColorBrush ConvertToSolidColorBrush(System.Drawing.Color color)
        {
            return new(Color.FromRgb(color.R, color.G, color.B));
        }
    }
}
