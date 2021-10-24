using System.Reflection;
using System.Windows.Input;
using Application.Client.Common.ViewModels;
using Application.Client.Dialogs.AboutDialog.Windows.ViewModels.Commands;

namespace Application.Client.Dialogs.AboutDialog.Windows.ViewModels
{
    public class AboutWindowViewModel : ViewModelBase
    {
        private ICommand? _okCommand;
        public ICommand OkCommand => _okCommand ??= new OkCommand(this);

        private ICommand? _navigateToGitHubProfileCommand;
        public ICommand NavigateToGitHubProfileCommand => _navigateToGitHubProfileCommand ??= new NavigateToGitHubProfileCommand(this);

        private ICommand? _navigateToGitHubRepositoryCommand;
        public ICommand NavigateToGitHubRepositoryCommand => _navigateToGitHubRepositoryCommand ??= new NavigateToGitHubRepositoryCommand(this);

        private ICommand? _navigateToSoftwareLicenseTermsCommand;
        public ICommand NavigateToSoftwareLicenseTermsCommand => _navigateToSoftwareLicenseTermsCommand ??= new NavigateToSoftwareLicenseTermsCommand(this);

        public string DisplayedImagePath => @"~\..\Assets\Images\application-icon.png";

        public string VersionNumber => Assembly.GetExecutingAssembly().GetName().Version!.ToString();
    }
}
