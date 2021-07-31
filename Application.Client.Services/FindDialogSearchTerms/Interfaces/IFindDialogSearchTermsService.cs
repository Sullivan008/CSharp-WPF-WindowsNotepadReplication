using Application.Client.Services.FindDialogSearchTerms.Enums;

namespace Application.Client.Services.FindDialogSearchTerms.Interfaces
{
    public interface IFindDialogSearchTermsService
    {
        public string Text { get; }

        public bool IsMatchCase { get; }

        public DirectionType DirectionType { get; }

        public bool HasSearchTerms { get; }
    }
}
