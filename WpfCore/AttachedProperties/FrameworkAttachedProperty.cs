using System.Windows;

namespace WpfCore
{
    public abstract class FrameworkAttachedProperty<Parent> : BaseAttachedProperty<Parent, bool> where Parent:BaseAttachedProperty<Parent, bool>, new()
    {
        public bool FirstLoad { get; set; } = true;
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            if (!(sender is FrameworkElement element))
                return;
            if (sender.GetValue(ValueProperty) == value && !FirstLoad)
                return;
            if (FirstLoad)
            {
                void onLoaded(object s, RoutedEventArgs e)
                {
                    element.Loaded -= onLoaded;
                    DoAction(element, (bool)value);
                    FirstLoad = false;
                }
                element.Loaded += onLoaded;
            }
            else
                DoAction(element, (bool)value);
        }
        protected virtual void DoAction(FrameworkElement element, bool value)
        {

        }
    }
}
