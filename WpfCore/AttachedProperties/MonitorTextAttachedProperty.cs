using System.Windows;
using System.Windows.Controls;

namespace WpfCore
{
    public class MonitorTextAttachedProperty:BaseAttachedProperty<MonitorTextAttachedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if(!(sender is TextBox textbox))
                    return;
            textbox.TextChanged -= Textbox_TextChanged;
            if((bool)e.NewValue)
            {
                HasTextAttachedProperty.SetValue(textbox);
                textbox.TextChanged += Textbox_TextChanged;
            }
        }

        private void Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            HasTextAttachedProperty.SetValue((TextBox)sender);
        }
    }
    public class HasTextAttachedProperty:BaseAttachedProperty<HasTextAttachedProperty, bool>
    {
        public static void SetValue(DependencyObject sender)
        {
            if (sender is TextBox textBox)
                SetValue(sender, textBox.Text.Length > 0);
        }
    }
}
