using Application.Client.Cache.DataModels.Replace.ReplacementConditions;
using Application.Client.Cache.Infrastructure.Enums;
using Application.Client.Cache.Infrastructure.Repository.Abstractions;
using Application.Client.Cache.Infrastructure.Repository.Interfaces;
using Application.Client.Cache.Infrastructure.Services.Interfaces;

namespace Application.Client.Cache.Repositories
{
    public class ReplacementConditionsCacheRepository : BaseCacheRepository<ReplacementConditionsDataModel>, ICacheRepository<ReplacementConditionsDataModel>
    {
        public ReplacementConditionsCacheRepository(IApplicationCacheService applicationCacheService) : base(applicationCacheService)
        { }

        protected override CacheKey GetCacheKey()
        {
            return CacheKey.ReplacementConditions;
        }
    }
}
