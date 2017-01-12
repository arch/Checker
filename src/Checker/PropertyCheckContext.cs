using System;

namespace Checking.FluentApi
{
    public class PropertyCheckContext<T, TProperty>
    {
        private readonly Lazy<TProperty> propertyValueContainer;

        public PropertyCheckContext(CheckContext<T> parentContext, PropertyRule<T, TProperty> rule, string propertyName)
        {
            ParentContext = parentContext;
            Rule = rule;
            PropertyName = propertyName;
            propertyValueContainer = new Lazy<TProperty>(() => rule.PropertyFunc(parentContext.InstanceToCheck));
        }

        public CheckContext<T> ParentContext { get; }

        public PropertyRule<T, TProperty> Rule { get; }

        public T Instance
        {
            get
            {
                return ParentContext.InstanceToCheck;
            }
        }

        public string PropertyName { get; }

        public TProperty PropertyValue
        {
            get { return propertyValueContainer.Value; }
        }
    }
}
