﻿using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Application.Client.Dialogs.FontDialog.Enums;
using Application.Client.Dialogs.FontDialog.Interfaces;
using Application.Client.Dialogs.FontDialog.Models.Options;
using Application.Client.Dialogs.FontDialog.Models.Result;
using Application.Client.Infrastructure.Commands;
using Application.Client.Windows.Main.ViewModels;

namespace Application.Client.Windows.Main.Commands.FormatMenu
{
    public class FontsCommand : AsyncCommandBase<MainWindowViewModel>
    {
        private readonly IFontDialog _fontDialog;

        public FontsCommand(MainWindowViewModel callerViewModel, IFontDialog fontDialog) : base(callerViewModel)
        {
            _fontDialog = fontDialog;
        }

        public override async Task ExecuteAsync()
        {
            FontDialogResult dialogResult = await _fontDialog.ShowFontDialogAsync(new FontDialogOptions());

            if (dialogResult.FontDialogResultType == FontDialogResultType.Ok)
            {
                CallerViewModel.InputTextBox.TextOptions.FontFamily = new FontFamily(dialogResult.FontResult.FontFamilyName);
                CallerViewModel.InputTextBox.TextOptions.FontSize = ConvertToMediaFontSize(dialogResult.FontResult.DrawingFontSize);
                CallerViewModel.InputTextBox.TextOptions.FontStyle = ConvertToWindowsFontStyle(dialogResult.FontResult.DrawingFontStyle);
                CallerViewModel.InputTextBox.TextOptions.FontWeight = ConvertToWindowsFontWeight(dialogResult.FontResult.DrawingFontStyle);
                CallerViewModel.InputTextBox.TextOptions.TextDecorations = ConvertToTextDecorationCollection(dialogResult.FontResult.DrawingFontStyle);
                CallerViewModel.InputTextBox.TextOptions.Foreground = ConvertToSolidColorBrush(dialogResult.FontResult.DrawingFontColor);
            }
        }

        private static float ConvertToMediaFontSize(float fontSize)
        {
            return (float)(fontSize * 96.0 / 72.0);
        }

        private static FontStyle ConvertToWindowsFontStyle(System.Drawing.FontStyle fontStyle)
        {
            return (fontStyle & System.Drawing.FontStyle.Italic) != 0 ? FontStyles.Italic : FontStyles.Normal;
        }

        private static FontWeight ConvertToWindowsFontWeight(System.Drawing.FontStyle fontStyle)
        {
            return (fontStyle & System.Drawing.FontStyle.Bold) != 0 ? FontWeights.Bold : FontWeights.Regular;
        }

        private static TextDecorationCollection ConvertToTextDecorationCollection(System.Drawing.FontStyle fontStyle)
        {
            TextDecorationCollection result = new();

            if ((fontStyle & System.Drawing.FontStyle.Strikeout) != 0)
            {
                result.Add(TextDecorations.Strikethrough);
            }

            if ((fontStyle & System.Drawing.FontStyle.Underline) != 0)
            {
                result.Add(TextDecorations.Underline);
            }

            return result;
        }

        private static SolidColorBrush ConvertToSolidColorBrush(System.Drawing.Color color)
        {
            return new (Color.FromRgb(color.R, color.G, color.B));
        }
    }
}
