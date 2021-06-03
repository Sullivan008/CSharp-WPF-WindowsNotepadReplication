using Application.Client.Core.ApplicationCache.Enums;
using Application.Client.Core.ApplicationCache.Models.Interfaces;
using Application.Client.Core.ApplicationCache.Models.Options;

namespace Application.Client.Core.ApplicationCache.Services.Interfaces
{
    public interface IApplicationCacheService
    {
        TCacheDataModel GetItem<TCacheDataModel>(CacheKey key) where TCacheDataModel : ICacheDataModel;

        void SetItem<TCacheDataModel>(CacheSaveOptions<TCacheDataModel> saveOptions) where TCacheDataModel : ICacheDataModel;

        void RemoveItem(CacheKey key);

        void Clear();
    }
}
