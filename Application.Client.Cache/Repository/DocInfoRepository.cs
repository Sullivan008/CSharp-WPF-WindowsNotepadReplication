﻿using Application.Client.Cache.Core.Enums;
using Application.Client.Cache.Core.Services.Interfaces;
using Application.Client.Cache.DataModels;
using Application.Client.Cache.Repository.Abstractions;
using Application.Client.Cache.Repository.Interfaces;

namespace Application.Client.Cache.Repository
{
    public class DocInfoRepository : BaseCacheRepository<DocInfoDataModel>, ICacheRepository<DocInfoDataModel>
    {
        public DocInfoRepository(IApplicationCacheService applicationCacheService) : base(applicationCacheService)
        { }

        protected override CacheKey GetCacheKey()
        {
            return CacheKey.DocInfo;
        }
    }
}
