using System;
using System.Collections.Generic;
using Application.Client.Cache.Core.Enums;
using Application.Client.Cache.Core.Models.Interfaces;
using Application.Client.Cache.Core.Models.Options;
using Application.Client.Cache.Core.Services.Interfaces;
using Application.Utilities.Extensions;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Client.Cache.Core.Services
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
            return _memoryCache.GetOrCreate(key.ToEnumMemberAttrValue(), entry =>
            {
                entry.Priority = CacheItemPriority.NeverRemove;

                return Activator.CreateInstance<TCacheDataModel>();
            });
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
