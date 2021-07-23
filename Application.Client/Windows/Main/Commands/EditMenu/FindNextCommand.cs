using System;
using System.Threading.Tasks;
using Application.Client.Infrastructure.Commands;
using Application.Client.Services.SearchTerms.Interfaces;
using Application.Client.Windows.Main.ViewModels;

namespace Application.Client.Windows.Main.Commands.EditMenu
{
    public class FindNextCommand : AsyncCommandBase<MainWindowViewModel>
    {
        private readonly ISearchTermsService _searchTermsService;

        public FindNextCommand(MainWindowViewModel callerViewModel, ISearchTermsService searchTermsService) : base(callerViewModel)
        {
            _searchTermsService = searchTermsService;
        }

        public override async Task ExecuteAsync()
        {
            CallerViewModel.WindowSettings.Activated = true;

            await Task.CompletedTask;
        }

        public override Predicate<object> CanExecute => _ => _searchTermsService.HasSearchTerms();
    }
}
