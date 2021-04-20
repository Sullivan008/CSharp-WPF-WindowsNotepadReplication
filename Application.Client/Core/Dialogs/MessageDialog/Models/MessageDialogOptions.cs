using System;
using System.Windows;

namespace Application.Client.Core.Dialogs.MessageDialog.Models
{
    public class MessageDialogOptions
    {
        private readonly MessageBoxButton? _button;
        public MessageBoxButton Button
        {
            get
            {
                if (!_button.HasValue)
                {
                    throw new ArgumentNullException(nameof(Button), @"The value cannot be null!");
                }

                return _button.Value;
            }
            init => _button = value;
        }

        private readonly MessageBoxImage? _icon;
        public MessageBoxImage Icon
        {
            get
            {
                if (!_icon.HasValue)
                {
                    throw new ArgumentNullException(nameof(Icon), @"The value cannot be null!");
                }

                return _icon.Value;
            }
            init => _icon = value;
        }

        private readonly string _title;
        public string Title
        {
            get => _title;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Title), @"The value cannot be null!");
                }

                _title = value;
            }
        }

        private readonly string _content;
        public string Content
        {
            get => _content;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Content), @"The value cannot be null!");
                }

                _content = value;
            }
        }
    }
}
