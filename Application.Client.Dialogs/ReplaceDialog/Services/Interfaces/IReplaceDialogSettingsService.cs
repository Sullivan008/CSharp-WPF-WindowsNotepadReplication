using Application.Client.Cache.DataModels.FindNext.SearchConditions.Enums;

namespace Application.Client.Dialogs.ReplaceDialog.Services.Interfaces
{
    public interface IReplaceDialogSettingsService
    {
        public string FindWhat { get; }

        public string ReplaceWith { get; }

        public bool IsMatchCase { get; }

        public DirectionType DirectionType { get; }

        public void SetFindWhat(string findWhat);

        public void SetReplaceWith(string replaceWith);

        public void SetIsMatchCase(bool isMatchCase);

        public void SetDirectionType(DirectionType directionType);
    }
}
