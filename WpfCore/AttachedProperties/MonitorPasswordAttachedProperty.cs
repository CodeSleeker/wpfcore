using System.Windows;
using System.Windows.Controls;

namespace WpfCore
{
    public class MonitorPasswordAttachedProperty : BaseAttachedProperty<MonitorPasswordAttachedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is PasswordBox passwordBox)) return;
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
            if ((bool)e.NewValue)
            {
                HasPasswordAttachedProperty.SetValue(passwordBox);
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasPasswordAttachedProperty.SetValue((PasswordBox)sender);
        }
    }
    public class HasPasswordAttachedProperty : BaseAttachedProperty<HasPasswordAttachedProperty, bool>
    {
        public static void SetValue(DependencyObject sender)
        {
            if (sender is PasswordBox passwordBox)
                SetValue(sender, passwordBox.SecurePassword.Length > 0);
        }
    }
}
