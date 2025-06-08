using System.Windows;
using System.Windows.Controls;

namespace Ticket2Help
{
    public static class PlaceholderService
    {
        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.RegisterAttached("PlaceholderText", typeof(string), typeof(PlaceholderService), new PropertyMetadata(string.Empty));

        public static string GetPlaceholderText(TextBox textBox)
        {
            return (string)textBox.GetValue(PlaceholderTextProperty);
        }

        public static void SetPlaceholderText(TextBox textBox, string value)
        {
            textBox.SetValue(PlaceholderTextProperty, value);
        }
    }
}
