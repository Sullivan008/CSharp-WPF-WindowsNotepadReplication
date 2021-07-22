using Application.Client.Cache.DataModels.FindDialog;
using Application.Client.Cache.Infrastructure.Repository.Interfaces;
using Application.Client.Services.SearchTerms.Enums;
using Application.Client.Services.SearchTerms.Exceptions;
using Application.Client.Services.SearchTerms.Interfaces;

namespace Application.Client.Services.SearchTerms
{
    public class SearchTermsService : ISearchTermsService
    {
        private readonly ICacheRepository<FindDialogSearchTermsDataModel> _findDialogSearchTermsCacheRepository;

        public SearchTermsService(ICacheRepository<FindDialogSearchTermsDataModel> findDialogSearchTermsCacheRepository)
        {
            _findDialogSearchTermsCacheRepository = findDialogSearchTermsCacheRepository;
        }

        public string Text
        {
            get
            {
                FindDialogSearchTermsDataModel findDialogSearchTerms = _findDialogSearchTermsCacheRepository.GetItem();

                return findDialogSearchTerms.Text;
            }
        }

        public DirectionType DirectionType
        {
            get
            {
                FindDialogSearchTermsDataModel findDialogSearchTerms = _findDialogSearchTermsCacheRepository.GetItem();

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
                FindDialogSearchTermsDataModel findDialogSearchTerms = _findDialogSearchTermsCacheRepository.GetItem();

                return findDialogSearchTerms.IsMatchCase;
            }
        }

        public bool HasSearchTerms()
        {
            FindDialogSearchTermsDataModel findDialogSearchTerms = _findDialogSearchTermsCacheRepository.GetItem();

            return !string.IsNullOrWhiteSpace(findDialogSearchTerms.Text);
        }

        public void SetText(string text)
        {
            FindDialogSearchTermsDataModel findDialogSearchTerms = _findDialogSearchTermsCacheRepository.GetItem();
            findDialogSearchTerms.Text = text;

            _findDialogSearchTermsCacheRepository.SetItem(findDialogSearchTerms);
        }

        public void SetDirectionType(DirectionType directionType)
        {
            FindDialogSearchTermsDataModel findDialogSearchTerms = _findDialogSearchTermsCacheRepository.GetItem();

            switch (directionType)
            {
                case DirectionType.Up:
                    findDialogSearchTerms.DirectionType = Cache.DataModels.FindDialog.Enums.DirectionType.Up;
                    break;
                case DirectionType.Down:
                    findDialogSearchTerms.DirectionType = Cache.DataModels.FindDialog.Enums.DirectionType.Down;
                    break;
                default:
                    throw new UnknownDirectionTypeException("An unknown error occurred while reading the direction type from input data!");
            }

            _findDialogSearchTermsCacheRepository.SetItem(findDialogSearchTerms);
        }

        public void SetIsMatchCase(bool isMatchCase)
        {
            FindDialogSearchTermsDataModel findDialogSearchTerms = _findDialogSearchTermsCacheRepository.GetItem();
            findDialogSearchTerms.IsMatchCase = isMatchCase;

            _findDialogSearchTermsCacheRepository.SetItem(findDialogSearchTerms);
        }
    }
}
