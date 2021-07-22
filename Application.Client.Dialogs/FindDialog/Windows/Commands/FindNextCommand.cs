using System;
using System.Threading.Tasks;
using Application.Client.Dialogs.FindDialog.Windows.ViewModels;
using Application.Client.Infrastructure.Commands;
using Application.Client.Services.SearchTerms.Interfaces;
using FluentValidation;

namespace Application.Client.Dialogs.FindDialog.Windows.Commands
{
    public class FindNextCommand : AsyncCommandBase<FindWindowViewModel>
    {
        private readonly IValidator<FindWindowViewModel> _validator;

        private readonly ISearchTermsService _searchTermsService;

        public FindNextCommand(FindWindowViewModel callerViewModel, IValidator<FindWindowViewModel> validator, ISearchTermsService searchTermsService) : base(callerViewModel)
        {
            _validator = validator;
            _searchTermsService = searchTermsService;
        }

        public override async Task ExecuteAsync()
        {
            SetSearchTermsIntoCache();

            OnFindNext();

            await Task.CompletedTask;
        }

        public override Predicate<object> CanExecute => _ => _validator.Validate(CallerViewModel).IsValid;

        private void SetSearchTermsIntoCache()
        {
            _searchTermsService.SetText(CallerViewModel.FindWhat);
            _searchTermsService.SetIsMatchCase(CallerViewModel.IsMatchCase);
            _searchTermsService.SetDirectionType((Services.SearchTerms.Enums.DirectionType)CallerViewModel.DirectionType);
        }

        private void OnFindNext(EventArgs eventArgs = null)
        {
            if (CallerViewModel.OnFindNextEvent == null)
            {
                throw new ArgumentNullException(nameof(CallerViewModel.OnFindNextEvent), "The value cannot be null!");
            }

            CallerViewModel.OnFindNextEvent(this, eventArgs ?? EventArgs.Empty);
        }
    }
}
