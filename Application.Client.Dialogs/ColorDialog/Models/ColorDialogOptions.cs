﻿namespace Application.Client.Dialogs.ColorDialog.Models
{
    public class ColorDialogOptions
    {
        public bool AllowFullOpen { get; init; } = true;

        public bool FullOpen { get; init; } = false;

        public bool AnyColor { get; init; } = true;

        public bool SolidColorOnly { get; init; } = false;
    }
}
