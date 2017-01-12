using System.Collections.Generic;

namespace Checking.FluentApi
{
    public interface IPropertyChecker<T, TProperty>
    {
        bool Succeed { get; }

        IEnumerable<CheckFailure> Checker(PropertyCheckContext<T, TProperty> context);
    }
}
