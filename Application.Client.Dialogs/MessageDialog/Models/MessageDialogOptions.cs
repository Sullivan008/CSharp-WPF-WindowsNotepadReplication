using System;
using System.Windows;

namespace Application.Client.Dialogs.MessageDialog.Models
{
    public class MessageDialogOptions
    {
        public MessageBoxImage? Icon { get; init; }

        private readonly MessageBoxButton? _button;
        public MessageBoxButton Button
        {
            get
            {
                if (!_button.HasValue)
                {
                    throw new ArgumentNullException(nameof(Button), "The value cannot be null!");
                }

                return _button.Value;
            }

            init => _button = value;
        }
        
        private readonly string? _title;
        public string Title
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_title))
                {
                    throw new ArgumentNullException(nameof(Title), "The value cannot be null!");
                }

                return _title;
            }

            init => _title = value;
        }

        private readonly string? _content;
        public string Content
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_content))
                {
                    throw new ArgumentNullException(nameof(Content), "The value cannot be null!");
                }

                return _content;
            }
            
            init => _content = value;
        }
    }
}
