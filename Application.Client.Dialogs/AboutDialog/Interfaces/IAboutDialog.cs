using System.Threading.Tasks;
using Application.Client.Dialogs.AboutDialog.Models;

namespace Application.Client.Dialogs.AboutDialog.Interfaces
{
    public interface IAboutDialog
    {
        public Task<AboutDialogResult> ShowDialogAsync();
    }
}
