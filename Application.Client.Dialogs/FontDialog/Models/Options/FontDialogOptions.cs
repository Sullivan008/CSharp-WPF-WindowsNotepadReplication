namespace Application.Client.Dialogs.FontDialog.Models.Options
{
    public class FontDialogOptions
    {
        public bool ShowEffects { get; init; } = true;

        public bool ShowColor { get; init; } = true;

        public bool FontMustExist { get; init; } = true;

        public bool AllowVectorFonts { get; init; } = true;

        public bool AllowVerticalFonts { get; init; } = true;

        public bool FixedPitchOnly { get; init; } = false;
    }
}
