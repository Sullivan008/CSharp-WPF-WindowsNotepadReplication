using Application.Client.Messenger.GenericMessages.DialogMessages.MessageContents;
using GalaSoft.MvvmLight.Messaging;

namespace Application.Client.Messenger.GenericMessages.DialogMessages
{
    public class FindNextMessage : GenericMessage<FindNextMessageContent?>
    {
        public FindNextMessage(object sender) : base(sender, default)
        { }
    }
}
