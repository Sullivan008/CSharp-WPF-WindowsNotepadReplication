using Application.Client.Messenger.GenericMessages.DialogMessages.Shared.MessageContents;
using GalaSoft.MvvmLight.Messaging;

namespace Application.Client.Messenger.GenericMessages.DialogMessages.Shared
{
    public class FindNextMessage : GenericMessage<FindNextMessageContent?>
    {
        public FindNextMessage(object sender) : base(sender, default)
        { }
    }
}
