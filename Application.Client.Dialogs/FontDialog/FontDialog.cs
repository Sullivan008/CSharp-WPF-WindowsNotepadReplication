using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Application.Client.Dialogs.FontDialog.Enums;
using Application.Client.Dialogs.FontDialog.Exceptions;
using Application.Client.Dialogs.FontDialog.Interfaces;
using Application.Client.Dialogs.FontDialog.Models.Options;
using Application.Client.Dialogs.FontDialog.Models.Result;
using FontStyle = System.Drawing.FontStyle;

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
                Font = CreateDrawingFont(fontDialogOptions.FontOptions)
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

        private static Font CreateDrawingFont(FontOptions fontOptions)
        {
            try
            {
                FontFamily fontFamily = new(fontOptions.FontFamilyName);
                float fontSize = ConvertToDrawingFontSize(fontOptions.FontSize);
                FontStyle fontStyle = ConvertToDrawingFontStyle(fontOptions.WindowsFontStyle, fontOptions.WindowsFontWeight, fontOptions.WindowsTextDecorations);

                return new Font(fontFamily, fontSize, fontStyle);
            }
            catch (ArgumentException)
            {
                throw new UnknownFontException($"The following font does not exist or not available on the source machine! Please reinstall the following font type: {fontOptions.FontFamilyName}");
            }
        }

        private static float ConvertToDrawingFontSize(float fontSize)
        {
            return (float)(fontSize * 72.0 / 96.0);
        }

        private static FontStyle ConvertToDrawingFontStyle(System.Windows.FontStyle windowsFontStyle, FontWeight windowsFontWeights, TextDecorationCollection windowsTextDecorationCollection)
        {
            FontStyle result;

            result = windowsFontStyle == FontStyles.Italic ? System.Drawing.FontStyle.Italic : System.Drawing.FontStyle.Regular;
            result ^= windowsFontWeights == FontWeights.Bold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular;

            if (windowsTextDecorationCollection.Any(x => x.Location == TextDecorationLocation.Strikethrough))
            {
                result ^= FontStyle.Strikeout;
            }

            if (windowsTextDecorationCollection.Any(x => x.Location == TextDecorationLocation.Underline))
            {
                result ^= FontStyle.Underline;
            }

            return result;
        }
    }
}
