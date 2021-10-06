using System;
using System.Drawing;
using Application.Client.Cache.DataModels;
using Application.Client.Cache.Infrastructure.Repository.Interfaces;
using Application.Client.Dialogs.FontDialog.Services.Interfaces;

namespace Application.Client.Dialogs.FontDialog.Services
{
    internal class FontDialogSettingsService : IFontDialogSettingsService
    {
        private readonly ICacheRepository<FontDialogSettingsDataModel> _fontDialogSettingCacheRepository;

        public FontDialogSettingsService(ICacheRepository<FontDialogSettingsDataModel> fontDialogSettingCacheRepository)
        {
            _fontDialogSettingCacheRepository = fontDialogSettingCacheRepository;
        }

        public Font Font
        {
            get
            {
                FontDialogSettingsDataModel fontDialogSettings = _fontDialogSettingCacheRepository.GetItem();

                if (fontDialogSettings.Font == null)
                {
                    const float DEFAULT_FONT_SIZE = 12;
                    const string DEFAULT_FONT_FAMILY_NAME = "Consolas";
                    const FontStyle DEFAULT_FONT_STYLE = FontStyle.Regular;

                    return new Font(new FontFamily(DEFAULT_FONT_FAMILY_NAME), DEFAULT_FONT_SIZE, DEFAULT_FONT_STYLE);
                }

                return fontDialogSettings.Font;
            }
        }

        public Color Color
        {
            get
            {
                FontDialogSettingsDataModel fontDialogSettings = _fontDialogSettingCacheRepository.GetItem();

                return fontDialogSettings.Color;
            }
        }

        public void SetFont(Font font)
        {
            if (font == null)
            {
                throw new ArgumentNullException(nameof(font), "The value cannot be null!");
            }

            FontDialogSettingsDataModel fontDialogSettings = _fontDialogSettingCacheRepository.GetItem();
            fontDialogSettings.Font = font;

            _fontDialogSettingCacheRepository.SetItem(fontDialogSettings);
        }

        public void SetColor(Color color)
        {
            FontDialogSettingsDataModel fontDialogSettings = _fontDialogSettingCacheRepository.GetItem();
            fontDialogSettings.Color = color;

            _fontDialogSettingCacheRepository.SetItem(fontDialogSettings);
        }
    }
}
