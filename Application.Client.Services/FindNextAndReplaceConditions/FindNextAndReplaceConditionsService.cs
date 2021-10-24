using Application.Client.Cache.DataModels.FindNextAndReplaceConditions;
using Application.Client.Cache.Infrastructure.Repository.Interfaces;
using Application.Client.Services.FindNextAndReplaceConditions.Enums;
using Application.Client.Services.FindNextAndReplaceConditions.Exceptions;
using Application.Client.Services.FindNextAndReplaceConditions.Interfaces;

namespace Application.Client.Services.FindNextAndReplaceConditions
{
    public class FindNextAndReplaceConditionsService : IFindNextAndReplaceConditionsService
    {
        private readonly ICacheRepository<FindNextAndReplaceConditionsDataModel> _findNextAndReplaceConditionsCacheRepository;

        public FindNextAndReplaceConditionsService(ICacheRepository<FindNextAndReplaceConditionsDataModel> findNextAndReplaceConditionsCacheRepository)
        {
            _findNextAndReplaceConditionsCacheRepository = findNextAndReplaceConditionsCacheRepository;
        }

        public string FindWhat
        {
            get
            {
                FindNextAndReplaceConditionsDataModel findNextAndReplaceConditions = _findNextAndReplaceConditionsCacheRepository.GetItem();

                return findNextAndReplaceConditions.FindWhat;
            }
        }

        public string ReplaceWith
        {
            get
            {
                FindNextAndReplaceConditionsDataModel findNextAndReplaceConditions = _findNextAndReplaceConditionsCacheRepository.GetItem();

                return findNextAndReplaceConditions.ReplaceWith;
            }
        }

        public DirectionType DirectionType
        {
            get
            {
                FindNextAndReplaceConditionsDataModel findNextAndReplaceConditions = _findNextAndReplaceConditionsCacheRepository.GetItem();

                return MapCacheDirectionTypeToServiceDirectionType(findNextAndReplaceConditions.DirectionType);
            }
        }

        private static DirectionType MapCacheDirectionTypeToServiceDirectionType(Cache.DataModels.FindNextAndReplaceConditions.Enums.DirectionType directionType)
        {
            return directionType switch
            {
                Cache.DataModels.FindNextAndReplaceConditions.Enums.DirectionType.Up => DirectionType.Up,
                Cache.DataModels.FindNextAndReplaceConditions.Enums.DirectionType.Down => DirectionType.Down,
                _ => throw new UnknownCacheDirectionTypeException("An unknown error occurred while reading the direction type from cache data!")
            };
        }
        
        public bool IsMatchCase
        {
            get
            {
                FindNextAndReplaceConditionsDataModel findNextAndReplaceConditions = _findNextAndReplaceConditionsCacheRepository.GetItem();

                return findNextAndReplaceConditions.IsMatchCase;
            }
        }

        public bool HasSearchTerms
        {
            get
            {
                FindNextAndReplaceConditionsDataModel findNextAndReplaceConditions = _findNextAndReplaceConditionsCacheRepository.GetItem();

                return !string.IsNullOrWhiteSpace(findNextAndReplaceConditions.FindWhat);
            }
        }

        public void SetFindWhat(string findWhat)
        {
            FindNextAndReplaceConditionsDataModel findNextAndReplaceConditions = _findNextAndReplaceConditionsCacheRepository.GetItem();
            findNextAndReplaceConditions.FindWhat = findWhat;

            _findNextAndReplaceConditionsCacheRepository.SetItem(findNextAndReplaceConditions);
        }

        public void SetReplaceWith(string replaceWith)
        {
            FindNextAndReplaceConditionsDataModel findNextAndReplaceConditions = _findNextAndReplaceConditionsCacheRepository.GetItem();
            findNextAndReplaceConditions.ReplaceWith = replaceWith;

            _findNextAndReplaceConditionsCacheRepository.SetItem(findNextAndReplaceConditions);
        }

        public void SetDirectionType(DirectionType directionType)
        {
            FindNextAndReplaceConditionsDataModel findNextAndReplaceConditions = _findNextAndReplaceConditionsCacheRepository.GetItem();
            findNextAndReplaceConditions.DirectionType = MapServiceDirectionTypeToCacheDirectionType(directionType);

            _findNextAndReplaceConditionsCacheRepository.SetItem(findNextAndReplaceConditions);
        }

        private static Cache.DataModels.FindNextAndReplaceConditions.Enums.DirectionType MapServiceDirectionTypeToCacheDirectionType(DirectionType directionType)
        {
            return directionType switch
            {
                DirectionType.Up => Cache.DataModels.FindNextAndReplaceConditions.Enums.DirectionType.Up,
                DirectionType.Down => Cache.DataModels.FindNextAndReplaceConditions.Enums.DirectionType.Down,
                _ => throw new UnknownServiceDirectionTypeException("An unknown error occurred while reading the direction type from service data!")
            };
        }

        public void SetIsMatchCase(bool isMatchCase)
        {
            FindNextAndReplaceConditionsDataModel findNextAndReplaceConditions = _findNextAndReplaceConditionsCacheRepository.GetItem();
            findNextAndReplaceConditions.IsMatchCase = isMatchCase;

            _findNextAndReplaceConditionsCacheRepository.SetItem(findNextAndReplaceConditions);
        }
    }
}
