using Application.Client.Cache.DataModels.FindDialog.Enums;

namespace Application.Client.Dialogs.FindDialog.Services.Interfaces
{
    public interface IFindDialogSettingsService
    {
        public string FindWhat { get; }

        public bool IsMatchCase { get; }

        public DirectionType DirectionType { get; }

        public void SetFindWhat(string findWhat);

        public void SetIsMatchCase(bool isMatchCase);

        public void SetDirectionType(DirectionType directionType);
    }
}
