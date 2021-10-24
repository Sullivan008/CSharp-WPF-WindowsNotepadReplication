using Application.Client.Messenger.GenericMessages.InputTextBoxMessages.MessageContents;
using GalaSoft.MvvmLight.Messaging;

namespace Application.Client.Messenger.GenericMessages.InputTextBoxMessages
{
    public class UpdateStatusBarColMessage : GenericMessage<UpdateStatusBarColMessageContent?>
    {
        public UpdateStatusBarColMessage(object sender) : base(sender, default)
        { }
    }
}
