using System;
using System.Collections.Generic;
using System.Linq;

namespace Checking.FluentApi
{
    internal class LessThanChecker<T, TProperty> : IPropertyChecker<T, TProperty> where TProperty : IComparable<TProperty>, IComparable
    {
        private readonly TProperty valueToCompare;

        public LessThanChecker(TProperty valueToCompare)
        {
            this.valueToCompare = valueToCompare;
        }

        public bool Succeed { get; private set; } = true;

        public IEnumerable<CheckFailure> Checker(PropertyCheckContext<T, TProperty> context)
        {
            if (context.PropertyValue.CompareTo(valueToCompare) >= 0)
            {
                Succeed = false;

                return new[] { new CheckFailure {
                    PropertyName = context.PropertyName,
                    ErrorMessage = $"The value of {context.PropertyName} must less then {valueToCompare}"}
                }.AsEnumerable();
            }

            return Enumerable.Empty<CheckFailure>();
        }
    }
}
