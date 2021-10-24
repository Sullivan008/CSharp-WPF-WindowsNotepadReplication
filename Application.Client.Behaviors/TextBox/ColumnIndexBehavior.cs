using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace Application.Client.Behaviors.TextBox
{
    public class ColumnIndexBehavior : Behavior<System.Windows.Controls.TextBox>
    {
        private const int ColumnIndexPropertyDefault = -485609317;

        public static readonly DependencyProperty ColumnIndexProperty =
            DependencyProperty.RegisterAttached("ColumnIndex", typeof(int), typeof(ColumnIndexBehavior),
                new FrameworkPropertyMetadata(ColumnIndexPropertyDefault, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, ColumnIndexChanged));

        public static int GetColumnIndex(DependencyObject dependencyObject)
        {
            return (int)dependencyObject.GetValue(ColumnIndexProperty);
        }

        public static void SetColumnIndex(DependencyObject dependencyObject, int i)
        {
            dependencyObject.SetValue(ColumnIndexProperty, i);
        }

        private static void ColumnIndexChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            if (dependencyObject is not System.Windows.Controls.TextBox textBox || eventArgs.OldValue is not int oldValue || eventArgs.NewValue is not int newValue)
            {
                return;
            }

            if (oldValue == ColumnIndexPropertyDefault && newValue != ColumnIndexPropertyDefault)
            {
                textBox.SelectionChanged += SelectionChangedForColumnIndex;
            }
            else if (oldValue != ColumnIndexPropertyDefault && newValue == ColumnIndexPropertyDefault)
            {
                textBox.SelectionChanged -= SelectionChangedForColumnIndex;
            }
        }

        private static void SelectionChangedForColumnIndex(object sender, RoutedEventArgs eventArgs)
        {
            if (sender is System.Windows.Controls.TextBox textBox)
            {
                int lineIndex = textBox.GetLineIndexFromCharacterIndex(textBox.CaretIndex);
                int columnIndex = textBox.CaretIndex - textBox.GetCharacterIndexFromLineIndex(lineIndex);

                SetColumnIndex(textBox, columnIndex);
            }
        }
    }
}
