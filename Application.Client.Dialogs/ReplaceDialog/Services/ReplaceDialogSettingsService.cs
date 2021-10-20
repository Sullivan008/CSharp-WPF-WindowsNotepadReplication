using Application.Client.Cache.DataModels.FindNext.SearchConditions;
using Application.Client.Cache.DataModels.FindNext.SearchConditions.Enums;
using Application.Client.Cache.DataModels.Replace.ReplacementConditions;
using Application.Client.Cache.Infrastructure.Repository.Interfaces;
using Application.Client.Dialogs.ReplaceDialog.Services.Interfaces;

namespace Application.Client.Dialogs.ReplaceDialog.Services
{
    internal class ReplaceDialogSettingsService : IReplaceDialogSettingsService
    {
        private readonly ICacheRepository<ReplacementConditionsDataModel> _replacementConditionsRepository;

        private readonly ICacheRepository<FindNextSearchConditionsDataModel> _findNextSearchConditionsRepository;
        
        public ReplaceDialogSettingsService(ICacheRepository<ReplacementConditionsDataModel> replacementConditionsRepository,
            ICacheRepository<FindNextSearchConditionsDataModel> findNextSearchConditionsRepository)
        {
            _replacementConditionsRepository = replacementConditionsRepository;
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

        public string ReplaceWith
        {
            get
            {
                ReplacementConditionsDataModel replacementConditions = _replacementConditionsRepository.GetItem();

                return replacementConditions.ReplaceWith;
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

        public DirectionType DirectionType 
        {
            get
            {
                FindNextSearchConditionsDataModel findNextSearchConditions = _findNextSearchConditionsRepository.GetItem();

                return findNextSearchConditions.DirectionType;
            }
        }

        public void SetFindWhat(string findWhat)
        {
            FindNextSearchConditionsDataModel findNextSearchConditions = _findNextSearchConditionsRepository.GetItem();
            findNextSearchConditions.FindWhat = findWhat;

            _findNextSearchConditionsRepository.SetItem(findNextSearchConditions);
        }

        public void SetReplaceWith(string replaceWith)
        {
            ReplacementConditionsDataModel replacementConditions = _replacementConditionsRepository.GetItem();
            replacementConditions.ReplaceWith = replaceWith;

            _replacementConditionsRepository.SetItem(replacementConditions);
        }

        public void SetIsMatchCase(bool isMatchCase)
        {
            FindNextSearchConditionsDataModel findNextSearchConditions = _findNextSearchConditionsRepository.GetItem();
            findNextSearchConditions.IsMatchCase = isMatchCase;

            _findNextSearchConditionsRepository.SetItem(findNextSearchConditions);
        }

        public void SetDirectionType(DirectionType directionType)
        {
            FindNextSearchConditionsDataModel findNextSearchConditions = _findNextSearchConditionsRepository.GetItem();
            findNextSearchConditions.DirectionType = directionType;

            _findNextSearchConditionsRepository.SetItem(findNextSearchConditions);
        }
    }
}
