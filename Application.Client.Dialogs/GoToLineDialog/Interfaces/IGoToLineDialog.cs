using System.Threading.Tasks;
using Application.Client.Dialogs.GoToLineDialog.Models;

namespace Application.Client.Dialogs.GoToLineDialog.Interfaces
{
    public interface IGoToLineDialog
    {
        Task<GoToLineDialogResult> ShowDialogAsync();
    }
}
