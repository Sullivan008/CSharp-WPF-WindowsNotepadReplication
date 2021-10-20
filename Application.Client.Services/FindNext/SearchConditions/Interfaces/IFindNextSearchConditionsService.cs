using Application.Client.Services.FindNext.SearchConditions.Enums;

namespace Application.Client.Services.FindNext.SearchConditions.Interfaces
{
    public interface IFindNextSearchConditionsService
    {
        public string Text { get; }

        public bool IsMatchCase { get; }

        public DirectionType DirectionType { get; }

        public bool HasSearchTerms { get; }
    }
}
