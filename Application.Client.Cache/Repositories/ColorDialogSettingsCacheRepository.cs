using Application.Client.Cache.DataModels;
using Application.Client.Cache.Infrastructure.Enums;
using Application.Client.Cache.Infrastructure.Repository.Abstractions;
using Application.Client.Cache.Infrastructure.Repository.Interfaces;
using Application.Client.Cache.Infrastructure.Services.Interfaces;

namespace Application.Client.Cache.Repositories
{
    public class ColorDialogSettingsCacheRepository : BaseCacheRepository<ColorDialogSettingsDataModel>, ICacheRepository<ColorDialogSettingsDataModel>
    {
        public ColorDialogSettingsCacheRepository(IApplicationCacheService applicationCacheService) : base(applicationCacheService)
        { }

        protected override CacheKey GetCacheKey()
        {
            return CacheKey.ColorDialogSettings;
        }
    }
}
