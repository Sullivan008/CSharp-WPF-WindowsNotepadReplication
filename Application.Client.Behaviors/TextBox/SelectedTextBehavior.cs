using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace Application.Client.Behaviors.TextBox
{
    public class SelectedTextBehavior : Behavior<System.Windows.Controls.TextBox>
    {
        private const string SELECTED_TEXT_DEFAULT_VALUE = "pxh3949%lm/";

        public static readonly DependencyProperty SelectedTextProperty =
            DependencyProperty.RegisterAttached("SelectedText", typeof(string), typeof(SelectedTextBehavior),
                new FrameworkPropertyMetadata(SELECTED_TEXT_DEFAULT_VALUE, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, SelectedTextChanged));

        public static string GetSelectedText(DependencyObject obj)
        {
            return (string)obj.GetValue(SelectedTextProperty);
        }

        public static void SetSelectedText(DependencyObject obj, string value)
        {
            obj.SetValue(SelectedTextProperty, value);
        }

        private static void SelectedTextChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            if (dependencyObject is not System.Windows.Controls.TextBox textBox)
            {
                return;
            }

            string oldValue = (eventArgs.OldValue as string)!;
            string newValue = (eventArgs.NewValue as string)!;

            if (oldValue == SELECTED_TEXT_DEFAULT_VALUE && newValue != SELECTED_TEXT_DEFAULT_VALUE)
            {
                textBox.SelectionChanged += SelectionChangedForSelectedText;
            }
            else if (oldValue != SELECTED_TEXT_DEFAULT_VALUE && newValue == SELECTED_TEXT_DEFAULT_VALUE)
            {
                textBox.SelectionChanged -= SelectionChangedForSelectedText;
            }

            if (newValue is not null && newValue != textBox.SelectedText)
            {
                textBox.SelectedText = newValue;
            }
        }

        private static void SelectionChangedForSelectedText(object sender, RoutedEventArgs eventArgs)
        {
            if (sender is System.Windows.Controls.TextBox textBox)
            {
                SetSelectedText(textBox, textBox.SelectedText);
            }
        }
    }
}
