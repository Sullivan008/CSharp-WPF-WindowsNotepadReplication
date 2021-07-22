using Application.Client.Services.SearchTerms.Enums;

namespace Application.Client.Services.SearchTerms.Interfaces
{
    public interface ISearchTermsService
    {
        public string Text { get; }

        public DirectionType DirectionType { get; }

        public bool IsMatchCase { get; }

        public bool HasSearchTerms();

        public void SetText(string text);

        public void SetDirectionType(DirectionType directionType);

        public void SetIsMatchCase(bool isMatchCase);
    }
}
