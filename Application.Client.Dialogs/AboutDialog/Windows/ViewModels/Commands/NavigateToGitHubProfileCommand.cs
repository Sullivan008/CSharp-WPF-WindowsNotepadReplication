using System.Diagnostics;
using System.Threading.Tasks;
using Application.Client.Common.Commands;

namespace Application.Client.Dialogs.AboutDialog.Windows.ViewModels.Commands
{
    public class NavigateToGitHubProfileCommand : AsyncCommandBase<AboutWindowViewModel>
    {
        public NavigateToGitHubProfileCommand(AboutWindowViewModel callerViewModel) : base(callerViewModel)
        { }

        public override async Task ExecuteAsync()
        {
            const string URL = "https://github.com/Sullivan008";

            ProcessStartInfo processStartInfo = new(URL) { UseShellExecute = true };
            Process process = Process.Start(processStartInfo)!;

            await process.WaitForExitAsync().ConfigureAwait(false);
        }
    }
}
