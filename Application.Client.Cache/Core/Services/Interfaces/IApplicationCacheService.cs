using Application.Client.Cache.Core.Enums;
using Application.Client.Cache.Core.Models.Interfaces;
using Application.Client.Cache.Core.Models.Options;

namespace Application.Client.Cache.Core.Services.Interfaces
{
    public interface IApplicationCacheService
    {
        TCacheDataModel GetItem<TCacheDataModel>(CacheKey key) where TCacheDataModel : ICacheDataModel;

        void SetItem<TCacheDataModel>(CacheSaveOptions<TCacheDataModel> saveOptions) where TCacheDataModel : ICacheDataModel;

        void RemoveItem(CacheKey key);

        void Clear();
    }
}
