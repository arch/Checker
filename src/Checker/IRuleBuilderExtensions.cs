using System;

namespace Checking.FluentApi
{
    public static class IRuleBuilderExtensions
    {
        public static IRuleBuilder<T, TProperty> NotEmpty<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetChecker(new NotEmptyChecker<T, TProperty>(default(TProperty)));
        }

        public static IRuleBuilder<T, TProperty> LessThan<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, TProperty valueToCompare)
            where TProperty : IComparable<TProperty>, IComparable
        {
            return ruleBuilder.SetChecker(new LessThanChecker<T, TProperty>(valueToCompare));
        }
    }
}
