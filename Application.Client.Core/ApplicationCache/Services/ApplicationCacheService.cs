using System.Collections.Generic;
using Application.Client.Core.ApplicationCache.Enums;
using Application.Client.Core.ApplicationCache.Exceptions;
using Application.Client.Core.ApplicationCache.Models.Interfaces;
using Application.Client.Core.ApplicationCache.Models.Options;
using Application.Client.Core.ApplicationCache.Services.Interfaces;
using Application.Utilities.Extensions;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Client.Core.ApplicationCache.Services
{
    public class ApplicationCacheService : IApplicationCacheService
    {
        private readonly IMemoryCache _memoryCache;

        private readonly HashSet<CacheKey> _memoryCacheKeys;

        public ApplicationCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _memoryCacheKeys = new HashSet<CacheKey>();
        }

        public TCacheDataModel GetItem<TCacheDataModel>(CacheKey key) where TCacheDataModel : ICacheDataModel
        {
            if (!_memoryCache.TryGetValue(key.ToEnumMemberAttrValue(), out TCacheDataModel cacheItem))
            {
                throw new CacheItemNotExistException($"Application Cache Item does not exist with this key: {nameof(key).ToUpper()}: {key}");
            }

            return cacheItem;
        }

        public void SetItem<TCacheDataModel>(CacheSaveOptions<TCacheDataModel> saveOptions) where TCacheDataModel : ICacheDataModel
        {
            _memoryCache.Set(saveOptions.Key.ToEnumMemberAttrValue(), saveOptions.Data, saveOptions.MemoryCacheEntryOptions);

            _memoryCacheKeys.Add(saveOptions.Key);
        }

        public void RemoveItem(CacheKey key)
        {
            _memoryCache.Remove(key.ToEnumMemberAttrValue());

            _memoryCacheKeys.Remove(key);
        }

        public void Clear()
        {
            foreach (CacheKey key in _memoryCacheKeys)
            {
                _memoryCache.Remove(key);
            }

            _memoryCacheKeys.Clear();
        }
    }
}
