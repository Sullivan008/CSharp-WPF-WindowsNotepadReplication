using Application.Client.Cache.DataModels.FindNext.SearchConditions;
using Application.Client.Cache.DataModels.FindNext.SearchConditions.Enums;
using Application.Client.Cache.Infrastructure.Repository.Interfaces;
using Application.Client.Dialogs.FindDialog.Services.Interfaces;

namespace Application.Client.Dialogs.FindDialog.Services
{
    internal class FindDialogSettingsService : IFindDialogSettingsService
    {
        private readonly ICacheRepository<FindNextSearchConditionsDataModel> _findNextSearchConditionsRepository;

        public FindDialogSettingsService(ICacheRepository<FindNextSearchConditionsDataModel> findNextSearchConditionsRepository)
        {
            _findNextSearchConditionsRepository = findNextSearchConditionsRepository;
        }

        public string FindWhat
        {
            get
            {
                FindNextSearchConditionsDataModel findNextSearchConditions = _findNextSearchConditionsRepository.GetItem();

                return findNextSearchConditions.FindWhat;
            }
        }

        public DirectionType DirectionType
        {
            get
            {
                FindNextSearchConditionsDataModel findNextSearchConditions = _findNextSearchConditionsRepository.GetItem();

                return findNextSearchConditions.DirectionType;
            }
        }

        public bool IsMatchCase
        {
            get
            {
                FindNextSearchConditionsDataModel findNextSearchConditions = _findNextSearchConditionsRepository.GetItem();

                return findNextSearchConditions.IsMatchCase;
            }
        }

        public void SetFindWhat(string findWhat)
        {
            FindNextSearchConditionsDataModel findNextSearchConditions = _findNextSearchConditionsRepository.GetItem();
            findNextSearchConditions.FindWhat = findWhat;

            _findNextSearchConditionsRepository.SetItem(findNextSearchConditions);
        }

        public void SetDirectionType(DirectionType directionType)
        {
            FindNextSearchConditionsDataModel findNextSearchConditions = _findNextSearchConditionsRepository.GetItem();
            findNextSearchConditions.DirectionType = directionType;

            _findNextSearchConditionsRepository.SetItem(findNextSearchConditions);
        }

        public void SetIsMatchCase(bool isMatchCase)
        {
            FindNextSearchConditionsDataModel findNextSearchConditions = _findNextSearchConditionsRepository.GetItem();
            findNextSearchConditions.IsMatchCase = isMatchCase;

            _findNextSearchConditionsRepository.SetItem(findNextSearchConditions);
        }
    }
}
