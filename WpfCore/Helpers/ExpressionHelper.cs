using System;
using System.Linq.Expressions;
using System.Reflection;

namespace WpfCore
{
    public static class ExpressionHelper
    {
        public static T GetPropertyValue<T>(this Expression<Func<T>> expression)
        {
            return expression.Compile().Invoke();
        }
        public static void SetPropertyValue<T>(this Expression<Func<T>> expression, T value)
        {
            var _expression = (expression as LambdaExpression).Body as MemberExpression;
            var propertyInfo = (PropertyInfo)_expression.Member;
            var target = Expression.Lambda(_expression.Expression).Compile().DynamicInvoke();
            propertyInfo.SetValue(target, value);
        }
    }
}
