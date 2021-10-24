using Application.Client.Cache.DataModels.FindNextAndReplaceConditions;
using Application.Client.Cache.Infrastructure.Enums;
using Application.Client.Cache.Infrastructure.Repository.Abstractions;
using Application.Client.Cache.Infrastructure.Repository.Interfaces;
using Application.Client.Cache.Infrastructure.Services.Interfaces;

namespace Application.Client.Cache.Repositories
{
    public class FindNextAndReplaceConditionsCacheRepository : BaseCacheRepository<FindNextAndReplaceConditionsDataModel>, ICacheRepository<FindNextAndReplaceConditionsDataModel>
    {
        public FindNextAndReplaceConditionsCacheRepository(IApplicationCacheService applicationCacheService) : base(applicationCacheService)
        { }

        protected override CacheKey GetCacheKey()
        {
            return CacheKey.FindNextAndReplaceConditions;
        }
    }
}
