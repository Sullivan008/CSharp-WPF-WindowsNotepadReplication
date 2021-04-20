using System.Threading.Tasks;
using Application.Client.Core.Dialogs.OpenFileDialog.Models;

namespace Application.Client.Core.Dialogs.OpenFileDialog.Interfaces
{
    public interface IOpenFileDialogService
    {
        public Task<OpenFileDialogResult> ShowDialogAsync(OpenFileDialogOptions options);
    }
}
