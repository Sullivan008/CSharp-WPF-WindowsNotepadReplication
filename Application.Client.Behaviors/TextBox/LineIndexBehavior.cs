using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace Application.Client.Behaviors.TextBox
{
    public class LineIndexBehavior : Behavior<System.Windows.Controls.TextBox>
    {
        private const int LineIndexPropertyDefault = -485609317;

        public static readonly DependencyProperty LineIndexProperty =
            DependencyProperty.RegisterAttached("LineIndex", typeof(int), typeof(LineIndexBehavior),
                new FrameworkPropertyMetadata(LineIndexPropertyDefault, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, LineIndexChanged));

        public static int GetLineIndex(DependencyObject dependencyObject)
        {
            return (int)dependencyObject.GetValue(LineIndexProperty);
        }

        public static void SetLineIndex(DependencyObject dependencyObject, int i)
        {
            dependencyObject.SetValue(LineIndexProperty, i);
        }

        private static void LineIndexChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            if (dependencyObject is not System.Windows.Controls.TextBox textBox || eventArgs.OldValue is not int oldValue || eventArgs.NewValue is not int newValue)
            {
                return;
            }

            if (oldValue == LineIndexPropertyDefault && newValue != LineIndexPropertyDefault)
            {
                textBox.SelectionChanged += SelectionChangedForLineIndex;
            }
            else if (oldValue != LineIndexPropertyDefault && newValue == LineIndexPropertyDefault)
            {
                textBox.SelectionChanged -= SelectionChangedForLineIndex;
            }
        }

        private static void SelectionChangedForLineIndex(object sender, RoutedEventArgs eventArgs)
        {
            if (sender is System.Windows.Controls.TextBox textBox)
            {
                SetLineIndex(textBox, textBox.GetLineIndexFromCharacterIndex(textBox.CaretIndex));
            }
        }
    }
}
