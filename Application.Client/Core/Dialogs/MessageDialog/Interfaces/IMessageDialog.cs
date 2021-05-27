using System.Threading.Tasks;
using Application.Client.Core.Dialogs.MessageDialog.Models;

namespace Application.Client.Core.Dialogs.MessageDialog.Interfaces
{
    public interface IMessageDialog
    {
        public Task<MessageDialogResult> ShowMessageDialogAsync(MessageDialogOptions options);
    }
}
