﻿using System.Drawing;
using System.Linq;
using Application.Client.Cache.DataModels;
using Application.Client.Cache.Repository.Interfaces;
using Application.Client.Services.Interfaces;

namespace Application.Client.Services
{
    public class ColorDialogSettingsService : IColorDialogSettingsService
    {
        private readonly ICacheRepository<ColorDialogSettingsDataModel> _colorDialogSettingsCacheRepository;

        public ColorDialogSettingsService(ICacheRepository<ColorDialogSettingsDataModel> colorDialogSettingsCacheRepository)
        {
            _colorDialogSettingsCacheRepository = colorDialogSettingsCacheRepository;
        }

        public Color Color
        {
            get
            {
                ColorDialogSettingsDataModel colorDialogSettings = _colorDialogSettingsCacheRepository.GetItem();

                if (colorDialogSettings == null)
                {
                    return Color.FromArgb(0, 0, 0);
                }

                return colorDialogSettings.Color;
            }
        }

        public int[] CustomColors
        {
            get
            {
                const int MAX_CUSTOM_COLOR_SIZE = 16;
                const int DEFAULT_CUSTOM_COLOR_VALUE = 16777215;

                ColorDialogSettingsDataModel colorDialogSettings = _colorDialogSettingsCacheRepository.GetItem();

                if (colorDialogSettings == null)
                {
                    return Enumerable.Repeat(DEFAULT_CUSTOM_COLOR_VALUE, MAX_CUSTOM_COLOR_SIZE).ToArray();
                }

                return colorDialogSettings.CustomColors;
            }
        }

        public void SetColor(Color color)
        {
            ColorDialogSettingsDataModel colorDialogSettings = _colorDialogSettingsCacheRepository.GetItem();
            colorDialogSettings.Color = color;

            _colorDialogSettingsCacheRepository.SetItem(colorDialogSettings);
        }

        public void SetCustomColors(int[] customColors)
        {
            ColorDialogSettingsDataModel colorDialogSettings = _colorDialogSettingsCacheRepository.GetItem();
            colorDialogSettings.CustomColors = customColors;

            _colorDialogSettingsCacheRepository.SetItem(colorDialogSettings);
        }
    }
}
