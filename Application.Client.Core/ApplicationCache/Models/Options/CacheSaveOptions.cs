using System;
using Application.Client.Core.ApplicationCache.Enums;
using Application.Client.Core.ApplicationCache.Models.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Client.Core.ApplicationCache.Models.Options
{
    public class CacheSaveOptions<TCacheDataModel> where TCacheDataModel : ICacheDataModel
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

        private readonly TCacheDataModel _data;
        public TCacheDataModel Data
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
