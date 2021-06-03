using System.Threading.Tasks;
using Application.Client.Dialogs.OpenFileDialog.Models;

namespace Application.Client.Dialogs.OpenFileDialog.Interfaces
{
    public interface IOpenFileDialog
    {
        public Task<OpenFileDialogResult> ShowDialogAsync(OpenFileDialogOptions options);
    }
}
