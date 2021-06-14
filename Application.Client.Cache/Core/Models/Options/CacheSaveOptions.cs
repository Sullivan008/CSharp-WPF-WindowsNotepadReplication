using System;
using Application.Client.Cache.Core.Enums;
using Application.Client.Cache.Core.Models.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Client.Cache.Core.Models.Options
{
    public class CacheSaveOptions<TCacheDataItem> where TCacheDataItem : ICacheDataModel
    {
        private readonly CacheKey? _key;
        public CacheKey Key
        {
            get
            {
                if (!_key.HasValue)
                {
                    throw new ArgumentNullException(nameof(Key), "The value cannot be null!");
                }

                return _key.Value;
            }
            init => _key = value;
        }

        private readonly TCacheDataItem _data;
        public TCacheDataItem Data
        {
            get
            {
                if (_data == null)
                {
                    throw new ArgumentNullException(nameof(Data), "The value cannot be null!");
                }

                return _data;
            } 
            init => _data = value;
        }

        private readonly MemoryCacheEntryOptions _memoryCacheEntryOptions;
        public MemoryCacheEntryOptions MemoryCacheEntryOptions
        {
            get
            {
                if (_memoryCacheEntryOptions == null)
                {
                    return new MemoryCacheEntryOptions {Priority = CacheItemPriority.NeverRemove};
                }

                return _memoryCacheEntryOptions;
            }
            init => _memoryCacheEntryOptions = value;
        }
    }
}
