using Application.Client.Messenger.GenericMessages.InputTextBoxMessages.MessageContents;
using GalaSoft.MvvmLight.Messaging;

namespace Application.Client.Messenger.GenericMessages.InputTextBoxMessages
{
    public class UpdateStatusBarLnMessage : GenericMessage<UpdateStatusBarLnMessageContent?>
    {
        public UpdateStatusBarLnMessage(object sender) : base(sender, default)
        { }
    }
}
