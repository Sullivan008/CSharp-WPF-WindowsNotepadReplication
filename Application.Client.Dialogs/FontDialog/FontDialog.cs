using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Client.Dialogs.FontDialog.Enums;
using Application.Client.Dialogs.FontDialog.Exceptions;
using Application.Client.Dialogs.FontDialog.Interfaces;
using Application.Client.Dialogs.FontDialog.Models.Options;
using Application.Client.Dialogs.FontDialog.Models.Result;
using Application.Client.Dialogs.FontDialog.Services.Interfaces;

namespace Application.Client.Dialogs.FontDialog
{
    public class FontDialog : IFontDialog
    {
        private readonly IFontDialogSettingsService _fontDialogSettingsService;

        public FontDialog(IFontDialogSettingsService fontDialogSettingsService)
        {
            _fontDialogSettingsService = fontDialogSettingsService;
        }

        public async Task<FontDialogResult> ShowDialogAsync(FontDialogOptions fontDialogOptions)
        {
            System.Windows.Forms.FontDialog fontDialog = new()
            {
                ShowEffects = fontDialogOptions.ShowEffects,
                ShowColor = fontDialogOptions.ShowColor,
                FontMustExist = fontDialogOptions.FontMustExist,
                AllowVectorFonts = fontDialogOptions.AllowVectorFonts,
                AllowVerticalFonts = fontDialogOptions.AllowVerticalFonts,
                FixedPitchOnly = fontDialogOptions.FixedPitchOnly,
                Font = _fontDialogSettingsService.Font,
                Color = _fontDialogSettingsService.Color
            };

            return fontDialog.ShowDialog() switch
            {
                DialogResult.OK => await OnOkResult(fontDialog),
                DialogResult.Cancel => await OnCancelResult(),
                DialogResult.None => throw new NotImplementedException($"No logic is implemented for this type of return! Type: {nameof(DialogResult.None)}"),
                DialogResult.No => throw new NotImplementedException($"No logic is implemented for this type of return! Type: {nameof(DialogResult.Cancel)}"),
                DialogResult.Abort => throw new NotImplementedException($"No logic is implemented for this type of return! Type: {nameof(DialogResult.Abort)}"),
                DialogResult.Retry => throw new NotImplementedException($"No logic is implemented for this type of return! Type: {nameof(DialogResult.Retry)}"),
                DialogResult.Ignore => throw new NotImplementedException($"No logic is implemented for this type of return! Type: {nameof(DialogResult.Ignore)}"),
                DialogResult.Yes => throw new NotImplementedException($"No logic is implemented for this type of return! Type: {nameof(DialogResult.Yes)}"),
                _ => throw new FontDialogUnknownResultTypeException("An unknown error occurred while reading the result of the dialog box!"),
            };
        }

        private Task<FontDialogResult> OnOkResult(System.Windows.Forms.FontDialog fontDialog)
        {
            _fontDialogSettingsService.SetFont(fontDialog.Font);
            _fontDialogSettingsService.SetColor(fontDialog.Color);

            return Task.FromResult(new FontDialogResult
            {
                FontDialogResultType = FontDialogResultType.Ok,
                FontResult = new FontResult
                {
                    FontFamilyName = fontDialog.Font.Name,
                    DrawingFontSize = fontDialog.Font.Size,
                    DrawingFontStyle = fontDialog.Font.Style,
                    DrawingFontColor = fontDialog.Color
                }
            });
        }

        private static Task<FontDialogResult> OnCancelResult()
        {
            return Task.FromResult(new FontDialogResult
            {
                FontDialogResultType = FontDialogResultType.Cancel
            });
        }
    }
}
