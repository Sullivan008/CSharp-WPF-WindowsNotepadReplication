using Application.Client.Cache.DataModels.FindDialog;
using Application.Client.Cache.Infrastructure.Enums;
using Application.Client.Cache.Infrastructure.Repository.Abstractions;
using Application.Client.Cache.Infrastructure.Repository.Interfaces;
using Application.Client.Cache.Infrastructure.Services.Interfaces;

namespace Application.Client.Cache.Repositories
{
    public class FindDialogSearchTermsCacheRepository : BaseCacheRepository<FindDialogSearchTermsDataModel>, ICacheRepository<FindDialogSearchTermsDataModel>
    {
        public FindDialogSearchTermsCacheRepository(IApplicationCacheService applicationCacheService) : base(applicationCacheService)
        { }

        protected override CacheKey GetCacheKey()
        {
            return CacheKey.FindDialogSearchTerms;
        }
    }
}
