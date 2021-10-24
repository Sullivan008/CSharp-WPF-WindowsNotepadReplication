using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace Application.Client.Behaviors.TextBox
{
    public class SelectionLengthBehavior : Behavior<System.Windows.Controls.TextBox>
    {
        private const int SelectionLengthPropertyDefault = -485609317;

        public static readonly DependencyProperty SelectionLengthProperty =
            DependencyProperty.RegisterAttached("SelectionLength", typeof(int), typeof(SelectionLengthBehavior),
                new FrameworkPropertyMetadata(SelectionLengthPropertyDefault, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, SelectionLengthChanged));

        public static int GetSelectionLength(DependencyObject dependencyObject)
        {
            return (int)dependencyObject.GetValue(SelectionLengthProperty);
        }

        public static void SetSelectionLength(DependencyObject dependencyObject, int i)
        {
            dependencyObject.SetValue(SelectionLengthProperty, i);
        }

        private static void SelectionLengthChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            if (dependencyObject is not System.Windows.Controls.TextBox textBox || eventArgs.OldValue is not int oldValue || eventArgs.NewValue is not int newValue)
            {
                return;
            }

            if (oldValue == SelectionLengthPropertyDefault && newValue != SelectionLengthPropertyDefault)
            {
                textBox.SelectionChanged += SelectionChangedForSelectionLength;
            }
            else if (oldValue != SelectionLengthPropertyDefault && newValue == SelectionLengthPropertyDefault)
            {
                textBox.SelectionChanged -= SelectionChangedForSelectionLength;
            }

            if (newValue != textBox.SelectionLength)
            {
                textBox.SelectionLength = newValue;
            }
        }

        private static void SelectionChangedForSelectionLength(object sender, RoutedEventArgs eventArgs)
        {
            if (sender is System.Windows.Controls.TextBox textBox)
            {
                SetSelectionLength(textBox, textBox.SelectionLength);
            }
        }
    }
}
