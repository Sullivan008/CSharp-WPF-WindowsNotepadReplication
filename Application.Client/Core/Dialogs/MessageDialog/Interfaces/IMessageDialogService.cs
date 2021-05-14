using System.Threading.Tasks;
using Application.Client.Core.Dialogs.MessageDialog.Models;

namespace Application.Client.Core.Dialogs.MessageDialog.Interfaces
{
    public interface IMessageDialogService
    {
        public Task<MessageDialogResult> ShowMessageDialogAsync(MessageDialogOptions options);
    }
}
