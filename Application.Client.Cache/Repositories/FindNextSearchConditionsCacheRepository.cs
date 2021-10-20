using Application.Client.Cache.DataModels.FindNext.SearchConditions;
using Application.Client.Cache.Infrastructure.Enums;
using Application.Client.Cache.Infrastructure.Repository.Abstractions;
using Application.Client.Cache.Infrastructure.Repository.Interfaces;
using Application.Client.Cache.Infrastructure.Services.Interfaces;

namespace Application.Client.Cache.Repositories
{
    public class FindNextSearchConditionsCacheRepository : BaseCacheRepository<FindNextSearchConditionsDataModel>, ICacheRepository<FindNextSearchConditionsDataModel>
    {
        public FindNextSearchConditionsCacheRepository(IApplicationCacheService applicationCacheService) : base(applicationCacheService)
        { }

        protected override CacheKey GetCacheKey()
        {
            return CacheKey.FindNextSearchConditions;
        }
    }
}
