using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfCore
{
    public abstract class BaseConverter<T> : MarkupExtension, IValueConverter where T : class, new()
    {
        private static T Converter = null;

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Converter ?? (Converter = new T());
        }
    }
}
