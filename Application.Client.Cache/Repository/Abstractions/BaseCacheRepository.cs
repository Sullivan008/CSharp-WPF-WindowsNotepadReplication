﻿using Application.Client.Cache.Core.Enums;
using Application.Client.Cache.Core.Models.Interfaces;
using Application.Client.Cache.Core.Models.Options;
using Application.Client.Cache.Core.Services.Interfaces;

namespace Application.Client.Cache.Repository.Abstractions
{
    public abstract class BaseCacheRepository<TCacheDataModel> where TCacheDataModel : ICacheDataModel
    {
        private readonly IApplicationCacheService _applicationCacheService;

        protected BaseCacheRepository(IApplicationCacheService applicationCacheService)
        {
            _applicationCacheService = applicationCacheService;
        }

        public TCacheDataModel GetItem()
        {
            return _applicationCacheService.GetItem<TCacheDataModel>(GetCacheKey());
        }

        public void SetItem(TCacheDataModel dataItem)
        {
            CacheSaveOptions<TCacheDataModel> saveOptions = new()
            {
                Key = GetCacheKey(),
                Data = dataItem
            };

            _applicationCacheService.SetItem(saveOptions);
        }

        protected abstract CacheKey GetCacheKey();
    }
}
