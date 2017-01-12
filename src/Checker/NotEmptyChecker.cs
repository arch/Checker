using System.Collections.Generic;
using System.Linq;

namespace Checking.FluentApi
{
    internal class NotEmptyChecker<T, TProperty> : IPropertyChecker<T, TProperty>
    {
        private readonly TProperty @default;

        public NotEmptyChecker(TProperty @default)
        {
            this.@default = @default;
        }

        public bool Succeed { get; private set; } = true;
        public IEnumerable<CheckFailure> Checker(PropertyCheckContext<T, TProperty> context)
        {
            if (context.PropertyValue == null || context.PropertyValue.Equals(@default))
            {
                Succeed = false;

                return new[] { new CheckFailure {
                    PropertyName = context.PropertyName,
                    ErrorMessage = $"The value of { context.PropertyName } connot be empty"}
                }.AsEnumerable();
            }

            return Enumerable.Empty<CheckFailure>();
        }
    }
}
