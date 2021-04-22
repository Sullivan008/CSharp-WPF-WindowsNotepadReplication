using System.Threading.Tasks;
using System.Windows;
using Application.Client.Core.Dialogs.MessageDialog.Enums;
using Application.Client.Core.Dialogs.MessageDialog.Exceptions;
using Application.Client.Core.Dialogs.MessageDialog.Interfaces;
using Application.Client.Core.Dialogs.MessageDialog.Models;

namespace Application.Client.Core.Dialogs.MessageDialog
{
    public class MessageDialogService : IMessageDialogService
    {
        public async Task<MessageDialogResult> ShowDialogAsync(MessageDialogOptions options)
        {
            switch (await ShowMessageDialogAsync(options))
            {
                case MessageBoxResult.OK:
                    return new MessageDialogResult { MessageDialogResultType = MessageDialogResultType.Ok };
                case MessageBoxResult.Yes:
                    return new MessageDialogResult { MessageDialogResultType = MessageDialogResultType.Yes };
                case MessageBoxResult.No:
                    return new MessageDialogResult { MessageDialogResultType = MessageDialogResultType.No };
                case MessageBoxResult.Cancel:
                    return new MessageDialogResult { MessageDialogResultType = MessageDialogResultType.Cancel };
                case MessageBoxResult.None:
                    return new MessageDialogResult { MessageDialogResultType = MessageDialogResultType.None };
                default:
                    throw new MessageDialogUnknownResultTypeException("An unknown error occurred while reading the result of the dialog box!");
            }
        }

        private static Task<MessageBoxResult> ShowMessageDialogAsync(MessageDialogOptions options)
        {
            return Task.Run(() => options.Icon.HasValue
                ? MessageBox.Show(options.Content, options.Title, options.Button, options.Icon.Value)
                : MessageBox.Show(options.Content, options.Title, options.Button));
        }
    }
}
