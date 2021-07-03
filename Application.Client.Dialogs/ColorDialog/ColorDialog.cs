using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Client.Dialogs.ColorDialog.Enums;
using Application.Client.Dialogs.ColorDialog.Exceptions;
using Application.Client.Dialogs.ColorDialog.Interfaces;
using Application.Client.Dialogs.ColorDialog.Models;
using Application.Client.Services.Interfaces;

namespace Application.Client.Dialogs.ColorDialog
{
    public class ColorDialog : IColorDialog
    {
        private readonly IColorDialogSettingsService _colorDialogSettingsService;

        public ColorDialog(IColorDialogSettingsService colorDialogSettingsService)
        {
            _colorDialogSettingsService = colorDialogSettingsService;
        }

        public async Task<ColorDialogResult> ShowColorDialogAsync(ColorDialogOptions dialogOptions)
        {
            System.Windows.Forms.ColorDialog colorDialog = new()
            {
                AllowFullOpen = dialogOptions.AllowFullOpen,
                FullOpen = dialogOptions.FullOpen,
                AnyColor = dialogOptions.AnyColor,
                SolidColorOnly = dialogOptions.SolidColorOnly,
                Color = _colorDialogSettingsService.Color,
                CustomColors = _colorDialogSettingsService.CustomColors
            };

            switch (colorDialog.ShowDialog())
            {
                case DialogResult.OK:
                    return await OnOkResult(colorDialog);
                case DialogResult.Cancel:
                    return await OnCancelResult();
                case DialogResult.None:
                    throw new NotImplementedException($"No logic is implemented for this type of return! Type: {nameof(DialogResult.None)}");
                case DialogResult.No:
                    throw new NotImplementedException($"No logic is implemented for this type of return! Type: {nameof(DialogResult.Cancel)}");
                case DialogResult.Abort:
                    throw new NotImplementedException($"No logic is implemented for this type of return! Type: {nameof(DialogResult.Abort)}");
                case DialogResult.Retry:
                    throw new NotImplementedException($"No logic is implemented for this type of return! Type: {nameof(DialogResult.Retry)}");
                case DialogResult.Ignore:
                    throw new NotImplementedException($"No logic is implemented for this type of return! Type: {nameof(DialogResult.Ignore)}");
                case DialogResult.Yes:
                    throw new NotImplementedException($"No logic is implemented for this type of return! Type: {nameof(DialogResult.Yes)}");
                default:
                    throw new ColorDialogUnknownResultTypeException("An unknown error occurred while reading the result of the dialog box!");
            }
        }

        private Task<ColorDialogResult> OnOkResult(System.Windows.Forms.ColorDialog colorDialog)
        {
            _colorDialogSettingsService.SetColor(colorDialog.Color);
            _colorDialogSettingsService.SetCustomColors(colorDialog.CustomColors);

            return Task.FromResult(new ColorDialogResult
            {
                ColorDialogResultType = ColorDialogResultType.Ok,
                Color = colorDialog.Color
            });
        }

        private Task<ColorDialogResult> OnCancelResult()
        {
            return Task.FromResult(new ColorDialogResult
            {
                ColorDialogResultType = ColorDialogResultType.Cancel
            });
        }
    }
}
