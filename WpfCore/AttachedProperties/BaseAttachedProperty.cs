using System;
using System.Windows;

namespace WpfCore
{
    public abstract class BaseAttachedProperty<Parent, Property> where Parent : new()
    {
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => {};
        public event Action<DependencyObject, object> ValueUpdated = (sender, e) => { };

        public static Parent Instance { get; private set; } = new Parent();

        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttachedProperty<Parent, Property>),
            new UIPropertyMetadata(default(Property), new PropertyChangedCallback(OnValuePropertyChanged), new CoerceValueCallback(OnValuePropertyUpdated)));

        private static void OnValuePropertyChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs e)
        {
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueChanged(dependency, e);
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueChanged(dependency, e);
        }

        private static object OnValuePropertyUpdated(DependencyObject dependency, object value)
        {
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueUpdated(dependency, value);
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueUpdated(dependency, value);
            return value;
        }

        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }
        public virtual void OnValueUpdated(DependencyObject sender, object value) { }

        public static Property GetValue(DependencyObject dependency) => (Property)dependency.GetValue(ValueProperty);
        public static void SetValue(DependencyObject dependency, Property value) => dependency.SetValue(ValueProperty, value);

    }
}
