using Application.Client.Messenger.GenericMessages.DialogMessages.ReplaceDialog.MessageContents;
using GalaSoft.MvvmLight.Messaging;

namespace Application.Client.Messenger.GenericMessages.DialogMessages.ReplaceDialog
{
    public class ReplaceNextMessage : GenericMessage<ReplaceNextMessageContent?>
    {
        public ReplaceNextMessage(object sender) : base(sender, default)
        { }
    }
}
