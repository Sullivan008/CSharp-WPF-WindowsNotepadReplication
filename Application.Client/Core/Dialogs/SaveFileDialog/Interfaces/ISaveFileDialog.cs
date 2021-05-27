using System.Threading.Tasks;
using Application.Client.Core.Dialogs.SaveFileDialog.Models;

namespace Application.Client.Core.Dialogs.SaveFileDialog.Interfaces
{
    public interface ISaveFileDialog
    {
        public Task<SaveFileDialogResult> ShowDialogAsync(SaveFileDialogOptions options);
    }
}
