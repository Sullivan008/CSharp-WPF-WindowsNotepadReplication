using Application.Client.Dialogs.FindDialog.Services.Exceptions;
using Application.Client.Dialogs.FindDialog.Services.Interfaces;
using Application.Client.Dialogs.FindDialog.Windows.ViewModels.Enums;
using Application.Client.Services.FindNextAndReplaceConditions.Interfaces;

namespace Application.Client.Dialogs.FindDialog.Services
{
    internal class FindDialogSettingsService : IFindDialogSettingsService
    {
        private readonly IFindNextAndReplaceConditionsService _findNextAndReplaceConditionsService;

        public FindDialogSettingsService(IFindNextAndReplaceConditionsService findNextAndReplaceConditionsService)
        {
            _findNextAndReplaceConditionsService = findNextAndReplaceConditionsService;
        }

        public string FindWhat => _findNextAndReplaceConditionsService.FindWhat;

        public DirectionType DirectionType
        {
            get
            {
                DirectionType result = MapServiceDirectionTypeToDialogDirectionType(_findNextAndReplaceConditionsService.DirectionType);

                return result;
            }
        }

        private static DirectionType MapServiceDirectionTypeToDialogDirectionType(Client.Services.FindNextAndReplaceConditions.Enums.DirectionType directionType)
        {
            return directionType switch
            {
                Client.Services.FindNextAndReplaceConditions.Enums.DirectionType.Up => DirectionType.Up,
                Client.Services.FindNextAndReplaceConditions.Enums.DirectionType.Down => DirectionType.Down,
                _ => throw new UnknownServiceDirectionTypeException("An unknown error occurred while reading the direction type from service data!")
            };
        }

        public bool IsMatchCase => _findNextAndReplaceConditionsService.IsMatchCase;

        public void SetFindWhat(string findWhat)
        {
            _findNextAndReplaceConditionsService.SetFindWhat(findWhat);
        }

        public void SetDirectionType(DirectionType directionType)
        {
            Client.Services.FindNextAndReplaceConditions.Enums.DirectionType result = MapDialogDirectionTypeToServiceDirectionType(directionType);
            
            _findNextAndReplaceConditionsService.SetDirectionType(result);
        }

        private static Client.Services.FindNextAndReplaceConditions.Enums.DirectionType MapDialogDirectionTypeToServiceDirectionType(DirectionType directionType)
        {
            return directionType switch
            {
                DirectionType.Up => Client.Services.FindNextAndReplaceConditions.Enums.DirectionType.Up,
                DirectionType.Down => Client.Services.FindNextAndReplaceConditions.Enums.DirectionType.Down,
                _ => throw new UnknownDialogDirectionTypeException("An unknown error occurred while reading the direction type from service data!")
            };
        }

        public void SetIsMatchCase(bool isMatchCase)
        {
            _findNextAndReplaceConditionsService.SetIsMatchCase(isMatchCase);
        }
    }
}
