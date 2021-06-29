namespace Application.Client.Dialogs.FontDialog.Models.Options
{
    public class FontDialogOptions
    {
        public bool ShowEffects { get; init; } = true;

        private readonly bool? _fontMustExist;
        public bool FontMustExist
        {
            get => _fontMustExist ?? true;
            init => _fontMustExist = value;
        }

        private readonly bool? _allowVectorFonts;
        public bool AllowVectorFonts
        {
            get => _allowVectorFonts ?? true;
            init => _allowVectorFonts = value;
        }

        private readonly bool? _allowVerticalFonts;
        public bool AllowVerticalFonts
        {
            get => _allowVerticalFonts ?? true;
            init => _allowVerticalFonts = value;
        }
        
        private readonly bool? _fixedPitchOnly;
        public bool FixedPitchOnly
        {
            get => _fixedPitchOnly ?? false;
            init => _fixedPitchOnly = value;
        }

        private readonly FontOptions _fontOptions;
        public FontOptions FontOptions
        {
            get => _fontOptions ?? new FontOptions();
            init => _fontOptions = value;
        }
    }
}
