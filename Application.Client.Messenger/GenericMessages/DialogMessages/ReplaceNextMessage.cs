using Application.Client.Messenger.GenericMessages.DialogMessages.MessageContents;
using GalaSoft.MvvmLight.Messaging;

namespace Application.Client.Messenger.GenericMessages.DialogMessages
{
    public class ReplaceNextMessage : GenericMessage<ReplaceNextMessageContent?>
    {
        public ReplaceNextMessage(object sender) : base(sender, default)
        { }
    }
}
