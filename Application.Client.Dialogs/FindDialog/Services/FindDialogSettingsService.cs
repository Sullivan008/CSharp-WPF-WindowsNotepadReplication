using Application.Client.Cache.DataModels.FindDialog;
using Application.Client.Cache.DataModels.FindDialog.Enums;
using Application.Client.Cache.Infrastructure.Repository.Interfaces;
using Application.Client.Dialogs.FindDialog.Services.Interfaces;

namespace Application.Client.Dialogs.FindDialog.Services
{
    public class FindDialogSettingsService : IFindDialogSettingsService
    {
        private readonly ICacheRepository<FindDialogSettingsDataModel> _findDialogSettingsRepository;

        public FindDialogSettingsService(ICacheRepository<FindDialogSettingsDataModel> findDialogSettingsRepository)
        {
            _findDialogSettingsRepository = findDialogSettingsRepository;
        }

        public string FindWhat
        {
            get
            {
                FindDialogSettingsDataModel findDialogSettings = _findDialogSettingsRepository.GetItem();

                return findDialogSettings.FindWhat;
            }
        }

        public DirectionType DirectionType
        {
            get
            {
                FindDialogSettingsDataModel findDialogSettings = _findDialogSettingsRepository.GetItem();

                return findDialogSettings.DirectionType;
            }
        }

        public bool IsMatchCase
        {
            get
            {
                FindDialogSettingsDataModel findDialogSettings = _findDialogSettingsRepository.GetItem();

                return findDialogSettings.IsMatchCase;
            }
        }

        public void SetFindWhat(string findWhat)
        {
            FindDialogSettingsDataModel findDialogSettings = _findDialogSettingsRepository.GetItem();
            findDialogSettings.FindWhat = findWhat;

            _findDialogSettingsRepository.SetItem(findDialogSettings);
        }

        public void SetDirectionType(DirectionType directionType)
        {
            FindDialogSettingsDataModel findDialogSettings = _findDialogSettingsRepository.GetItem();
            findDialogSettings.DirectionType = directionType;

            _findDialogSettingsRepository.SetItem(findDialogSettings);
        }

        public void SetIsMatchCase(bool isMatchCase)
        {
            FindDialogSettingsDataModel findDialogSettings = _findDialogSettingsRepository.GetItem();
            findDialogSettings.IsMatchCase = isMatchCase;

            _findDialogSettingsRepository.SetItem(findDialogSettings);
        }
    }
}
