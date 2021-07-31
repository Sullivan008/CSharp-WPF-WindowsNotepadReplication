using Application.Client.Cache.DataModels.FindDialog;
using Application.Client.Cache.Infrastructure.Repository.Interfaces;
using Application.Client.Services.FindDialogSearchTerms.Enums;
using Application.Client.Services.FindDialogSearchTerms.Exceptions;
using Application.Client.Services.FindDialogSearchTerms.Interfaces;

namespace Application.Client.Services.FindDialogSearchTerms
{
    public class FindDialogSearchTermsService : IFindDialogSearchTermsService
    {
        private readonly ICacheRepository<FindDialogSettingsDataModel> _findDialogSettingsCacheRepository;

        public FindDialogSearchTermsService(ICacheRepository<FindDialogSettingsDataModel> findDialogSearchTermsCacheRepository)
        {
            _findDialogSettingsCacheRepository = findDialogSearchTermsCacheRepository;
        }

        public string Text
        {
            get
            {
                FindDialogSettingsDataModel findDialogSearchTerms = _findDialogSettingsCacheRepository.GetItem();

                return findDialogSearchTerms.FindWhat;
            }
        }

        public DirectionType DirectionType
        {
            get
            {
                FindDialogSettingsDataModel findDialogSearchTerms = _findDialogSettingsCacheRepository.GetItem();

                switch (findDialogSearchTerms.DirectionType)
                {
                    case Cache.DataModels.FindDialog.Enums.DirectionType.Up:
                        return DirectionType.Up;
                    case Cache.DataModels.FindDialog.Enums.DirectionType.Down:
                        return DirectionType.Down;
                    default:
                        throw new UnknownCacheDirectionTypeException("An unknown error occurred while reading the direction type from cache data!");
                }
            }
        }


        public bool IsMatchCase
        {
            get
            {
                FindDialogSettingsDataModel findDialogSearchTerms = _findDialogSettingsCacheRepository.GetItem();

                return findDialogSearchTerms.IsMatchCase;
            }
        }

        public bool HasSearchTerms
        {
            get
            {
                FindDialogSettingsDataModel findDialogSearchTerms = _findDialogSettingsCacheRepository.GetItem();

                return !string.IsNullOrWhiteSpace(findDialogSearchTerms.FindWhat);
            }
        }
    }
}
