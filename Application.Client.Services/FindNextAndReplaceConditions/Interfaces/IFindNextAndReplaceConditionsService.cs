using Application.Client.Services.FindNextAndReplaceConditions.Enums;

namespace Application.Client.Services.FindNextAndReplaceConditions.Interfaces
{
    public interface IFindNextAndReplaceConditionsService
    {
        public string FindWhat { get; }

        public string ReplaceWith { get; }

        public bool IsMatchCase { get; }

        public DirectionType DirectionType { get; }

        public bool HasSearchTerms { get; }

        public void SetFindWhat(string findWhat);

        public void SetReplaceWith(string replaceWith);

        public void SetIsMatchCase(bool isMatchCase);

        public void SetDirectionType(DirectionType directionType);
    }
}
