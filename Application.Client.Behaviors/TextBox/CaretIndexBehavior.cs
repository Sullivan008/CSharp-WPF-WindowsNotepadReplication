using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace Application.Client.Behaviors.TextBox
{
    public class CaretIndexBehavior : Behavior<System.Windows.Controls.TextBox>
    {
        private const int CaretIndexPropertyDefault = -485609317;

        public static readonly DependencyProperty CaretIndexProperty =
            DependencyProperty.RegisterAttached("CaretIndex", typeof(int), typeof(CaretIndexBehavior), 
                new FrameworkPropertyMetadata(CaretIndexPropertyDefault, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, CaretIndexChanged));

        public static int GetCaretIndex(DependencyObject dependencyObject)
        {
            return (int)dependencyObject.GetValue(CaretIndexProperty);
        }

        public static void SetCaretIndex(DependencyObject dependencyObject, int i)
        {
            dependencyObject.SetValue(CaretIndexProperty, i);
        }

        private static void CaretIndexChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            if (dependencyObject is not System.Windows.Controls.TextBox textBox || eventArgs.OldValue is not int oldValue || eventArgs.NewValue is not int newValue)
            {
                return;
            }

            if (oldValue == CaretIndexPropertyDefault && newValue != CaretIndexPropertyDefault)
            {
                textBox.SelectionChanged += SelectionChangedForCaretIndex;
            }
            else if (oldValue != CaretIndexPropertyDefault && newValue == CaretIndexPropertyDefault)
            {
                textBox.SelectionChanged -= SelectionChangedForCaretIndex;
            }

            if (newValue != textBox.CaretIndex)
            {
                textBox.CaretIndex = newValue;
            }
        }

        private static void SelectionChangedForCaretIndex(object sender, RoutedEventArgs eventArgs)
        {
            if (sender is System.Windows.Controls.TextBox textBox)
            {
                SetCaretIndex(textBox, textBox.CaretIndex);
            }
        }
    }
}
