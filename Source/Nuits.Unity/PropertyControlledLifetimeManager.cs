using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Microsoft.Practices.Unity;

namespace Nuits.Unity
{
    public class PropertyControlledLifetimeManager<TValue> : LifetimeManager where TValue : class, INotifyPropertyChanged
    {
        private string PropertyName { get; }
        private Func<TValue, bool> IsCompleted { get; }
        private TValue Value { get; set; }
        public PropertyControlledLifetimeManager(Expression<Func<TValue, bool>> propertySelector)
        {
            if(propertySelector == null) throw new ArgumentNullException(nameof(propertySelector));

            var memberExpression = propertySelector.Body as MemberExpression;

            if(memberExpression == null) throw new ArgumentException("propertySelector.Body is not MemberExpression.");

            PropertyName = memberExpression.Member.Name;
            IsCompleted = propertySelector.Compile();
        }

        public override object GetValue()
        {
            return Value;
        }

        public override void SetValue(object newValue)
        {
            if(newValue == null) throw new ArgumentNullException(nameof(newValue));

            Value = newValue as TValue;

            if(Value == null) throw new ArgumentException($"newValue is not {typeof(TValue).FullName}");

            Value.PropertyChanged += ValueOnPropertyChanged;
        }

        private void ValueOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (Equals(PropertyName, args.PropertyName) && IsCompleted(Value))
            {
                RemoveValue();
            }
        }

        public override void RemoveValue()
        {
            (Value as IDisposable)?.Dispose();
            Value.PropertyChanged -= ValueOnPropertyChanged;
            Value = null;
        }
    }
}
