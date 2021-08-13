using System.Threading.Tasks;
using Application.Client.Dialogs.ReplaceDialog.Interfaces;

namespace Application.Client.Dialogs.ReplaceDialog
{
    public class ReplaceDialog : IReplaceDialog
    {
        public Task ShowAsync()
        {
            return Task.CompletedTask;
        }
    }
}
