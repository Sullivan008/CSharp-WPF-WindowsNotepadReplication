using Application.Client.Messenger.GenericMessages.DialogMessages.ReplaceDialog.MessageContents;
using GalaSoft.MvvmLight.Messaging;

namespace Application.Client.Messenger.GenericMessages.DialogMessages.ReplaceDialog
{
    public class ReplaceAllMessage : GenericMessage<ReplaceAllMessageContent?>
    {
        public ReplaceAllMessage(object sender) : base(sender, default)
        { }
    }
}
