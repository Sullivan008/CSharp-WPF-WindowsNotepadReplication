using Application.Client.Cache.DataModels.FindNext.SearchConditions;
using Application.Client.Cache.Infrastructure.Repository.Interfaces;
using Application.Client.Services.FindNext.SearchConditions.Enums;
using Application.Client.Services.FindNext.SearchConditions.Exceptions;
using Application.Client.Services.FindNext.SearchConditions.Interfaces;

namespace Application.Client.Services.FindNext.SearchConditions
{
    public class FindNextSearchConditionsService : IFindNextSearchConditionsService
    {
        private readonly ICacheRepository<FindNextSearchConditionsDataModel> _findDialogSettingsCacheRepository;

        public FindNextSearchConditionsService(ICacheRepository<FindNextSearchConditionsDataModel> findDialogSearchTermsCacheRepository)
        {
            _findDialogSettingsCacheRepository = findDialogSearchTermsCacheRepository;
        }

        public string Text
        {
            get
            {
                FindNextSearchConditionsDataModel findDialogSearchTerms = _findDialogSettingsCacheRepository.GetItem();

                return findDialogSearchTerms.FindWhat;
            }
        }

        public DirectionType DirectionType
        {
            get
            {
                FindNextSearchConditionsDataModel findDialogSearchTerms = _findDialogSettingsCacheRepository.GetItem();

                return findDialogSearchTerms.DirectionType switch
                {
                    Cache.DataModels.FindNext.SearchConditions.Enums.DirectionType.Up => DirectionType.Up,
                    Cache.DataModels.FindNext.SearchConditions.Enums.DirectionType.Down => DirectionType.Down,
                    _ => throw new UnknownCacheDirectionTypeException("An unknown error occurred while reading the direction type from cache data!")
                };
            }
        }
        
        public bool IsMatchCase
        {
            get
            {
                FindNextSearchConditionsDataModel findDialogSearchTerms = _findDialogSettingsCacheRepository.GetItem();

                return findDialogSearchTerms.IsMatchCase;
            }
        }

        public bool HasSearchTerms
        {
            get
            {
                FindNextSearchConditionsDataModel findDialogSearchTerms = _findDialogSettingsCacheRepository.GetItem();

                return !string.IsNullOrWhiteSpace(findDialogSearchTerms.FindWhat);
            }
        }
    }
}
