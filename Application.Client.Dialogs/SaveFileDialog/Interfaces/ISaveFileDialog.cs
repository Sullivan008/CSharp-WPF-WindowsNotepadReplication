using System.Threading.Tasks;
using Application.Client.Dialogs.SaveFileDialog.Models;

namespace Application.Client.Dialogs.SaveFileDialog.Interfaces
{
    public interface ISaveFileDialog
    {
        public Task<SaveFileDialogResult> ShowDialogAsync(SaveFileDialogOptions options);
    }
}
