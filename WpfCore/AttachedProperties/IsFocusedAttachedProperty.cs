using System.Windows;
using System.Windows.Controls;

namespace WpfCore
{
    public class IsFocusedAttachedProperty : BaseAttachedProperty<IsFocusedAttachedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is Control control)) return;
            control.Loaded += (s, ee) =>
            {
                control.Focus();
            };
        }
    }
}
