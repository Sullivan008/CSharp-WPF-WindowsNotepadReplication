using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace Application.Client.Behaviors.TextBox
{
    public class AllowableCharactersBehavior : Behavior<System.Windows.Controls.TextBox>
    {
        private const string RegularExpressionPropertyDefaultValue = ".*";

        public static readonly DependencyProperty RegularExpressionProperty =
            DependencyProperty.Register("RegularExpression", typeof(string), typeof(AllowableCharactersBehavior),
                new FrameworkPropertyMetadata(RegularExpressionPropertyDefaultValue));

        public string RegularExpression
        {
            get => (string)GetValue(RegularExpressionProperty);
            set => SetValue(RegularExpressionProperty, value);
        }

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.PreviewTextInput += OnPreviewTextInput;

            DataObject.AddPastingHandler(AssociatedObject, OnPaste);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.PreviewTextInput -= OnPreviewTextInput;

            DataObject.RemovePastingHandler(AssociatedObject, OnPaste);
        }

        private void OnPaste(object sender, DataObjectPastingEventArgs eventArgs)
        {
            if (eventArgs.DataObject.GetDataPresent(DataFormats.Text))
            {
                string text = Convert.ToString(eventArgs.DataObject.GetData(DataFormats.Text), CultureInfo.CurrentCulture);

                if (!IsValid(text))
                {
                    eventArgs.CancelCommand();
                }
            }
            else
            {
                eventArgs.CancelCommand();
            }
        }

        private void OnPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs eventArgs)
        {
            eventArgs.Handled = !IsValid(eventArgs.Text);
        }

        private bool IsValid(string newText)
        {
            return Regex.IsMatch(newText, RegularExpression);
        }
    }
}
