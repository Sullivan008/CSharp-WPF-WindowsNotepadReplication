﻿using Application.Client.Cache.DataModels;
using Application.Client.Cache.Infrastructure.Enums;
using Application.Client.Cache.Infrastructure.Repository.Abstractions;
using Application.Client.Cache.Infrastructure.Repository.Interfaces;
using Application.Client.Cache.Infrastructure.Services.Interfaces;

namespace Application.Client.Cache.Repositories
{
    public class FontDialogSettingsCacheRepository : BaseCacheRepository<FontDialogSettingsDataModel>, ICacheRepository<FontDialogSettingsDataModel>
    {
        public FontDialogSettingsCacheRepository(IApplicationCacheService applicationCacheService) : base(applicationCacheService)
        { }

        protected override CacheKey GetCacheKey()
        {
            return CacheKey.FontDialogSettings;
        }
    }
}
