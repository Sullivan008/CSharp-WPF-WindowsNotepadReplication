using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Client.Dialogs.FontDialog.Enums;
using Application.Client.Dialogs.FontDialog.Exceptions;
using Application.Client.Dialogs.FontDialog.Interfaces;
using Application.Client.Dialogs.FontDialog.Models.Options;
using Application.Client.Dialogs.FontDialog.Models.Result;

namespace Application.Client.Dialogs.FontDialog
{
    public class FontDialog : IFontDialog
    {
        public async Task<FontDialogResult> ShowFontDialogAsync(FontDialogOptions fontDialogOptions)
        {
            System.Windows.Forms.FontDialog fontDialog = new()
            {
                ShowEffects = fontDialogOptions.ShowEffects,
                FontMustExist = fontDialogOptions.FontMustExist,
                AllowVectorFonts = fontDialogOptions.AllowVectorFonts,
                AllowVerticalFonts = fontDialogOptions.AllowVerticalFonts,
                FixedPitchOnly = fontDialogOptions.FixedPitchOnly,
                Font = GetDrawingFont(fontDialogOptions.FontOptions)
            };

            switch (fontDialog.ShowDialog())
            {
                case DialogResult.OK:
                    return await Task.FromResult(
                        new FontDialogResult
                        {
                            FontDialogResultType = FontDialogResultType.Ok,
                            FontResult = new FontResult
                            {
                                FontFamilyName = fontDialog.Font.Name,
                                DrawingFontSize = fontDialog.Font.Size,
                                DrawingFontStyle = fontDialog.Font.Style
                            }
                        });
                case DialogResult.Cancel:
                    return await Task.FromResult(
                        new FontDialogResult
                        {
                            FontDialogResultType = FontDialogResultType.Cancel
                        });
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
                    throw new FontDialogUnknownResultTypeException("An unknown error occurred while reading the result of the dialog box!");
            }
        }

        private static Font GetDrawingFont(FontOptions fontOptions)
        {
            return new(fontOptions.FontFamily, fontOptions.FontSize, fontOptions.FontStyle);
        }
    }
}
