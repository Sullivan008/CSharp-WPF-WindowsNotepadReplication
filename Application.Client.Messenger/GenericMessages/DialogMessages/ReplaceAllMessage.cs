using Application.Client.Messenger.GenericMessages.DialogMessages.MessageContents;
using GalaSoft.MvvmLight.Messaging;

namespace Application.Client.Messenger.GenericMessages.DialogMessages
{
    public class ReplaceAllMessage : GenericMessage<ReplaceAllMessageContent?>
    {
        public ReplaceAllMessage(object sender) : base(sender, default)
        { }
    }
}
