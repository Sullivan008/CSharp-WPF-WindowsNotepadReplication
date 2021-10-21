using Application.Client.Dialogs.ReplaceDialog.Services.Interfaces;
using Application.Client.Services.FindNextAndReplaceConditions.Enums;
using Application.Client.Services.FindNextAndReplaceConditions.Interfaces;

namespace Application.Client.Dialogs.ReplaceDialog.Services
{
    internal class ReplaceDialogSettingsService : IReplaceDialogSettingsService
    {
        private readonly IFindNextAndReplaceConditionsService _findNextAndReplaceConditionsService;

        public ReplaceDialogSettingsService(IFindNextAndReplaceConditionsService findNextAndReplaceConditionsService)
        {
            _findNextAndReplaceConditionsService = findNextAndReplaceConditionsService;
        }

        public string FindWhat => _findNextAndReplaceConditionsService.FindWhat;

        public string ReplaceWith => _findNextAndReplaceConditionsService.ReplaceWith;

        public bool IsMatchCase => _findNextAndReplaceConditionsService.IsMatchCase;

        public void SetFindWhat(string findWhat)
        {
            _findNextAndReplaceConditionsService.SetFindWhat(findWhat);
        }

        public void SetReplaceWith(string replaceWith)
        {
            _findNextAndReplaceConditionsService.SetReplaceWith(replaceWith);
        }

        public void SetIsMatchCase(bool isMatchCase)
        {
            _findNextAndReplaceConditionsService.SetIsMatchCase(isMatchCase);
        }

        public void SetDirectionTypeToDefaultValue()
        {
            _findNextAndReplaceConditionsService.SetDirectionType(DirectionType.Up);
        }
    }
}
