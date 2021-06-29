using System;
using Application.Client.Dialogs.MessageDialog.Enums;

namespace Application.Client.Dialogs.MessageDialog.Models
{
    public class MessageDialogResult
    {
        private readonly MessageDialogResultType? _messageDialogResultType;
        public MessageDialogResultType MessageDialogResultType
        {
            get
            {
                if (!_messageDialogResultType.HasValue)
                {
                    throw new ArgumentNullException(nameof(_messageDialogResultType), "The value cannot be null!");
                }

                return _messageDialogResultType.Value;
            }

            init => _messageDialogResultType = value;
        }
    }
}
