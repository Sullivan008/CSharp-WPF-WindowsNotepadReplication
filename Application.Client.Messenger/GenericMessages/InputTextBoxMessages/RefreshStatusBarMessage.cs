using Application.Client.Messenger.GenericMessages.InputTextBoxMessages.MessageContents;
using GalaSoft.MvvmLight.Messaging;

namespace Application.Client.Messenger.GenericMessages.InputTextBoxMessages
{
    public class RefreshStatusBarMessage : GenericMessage<RefreshStatusBarMessageContent>
    {
        public RefreshStatusBarMessage(object sender) : base(sender, default)
        { }
    }
}
