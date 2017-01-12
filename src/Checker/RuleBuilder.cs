namespace Checking.FluentApi
{
    internal class RuleBuilder<T, TProperty> : IRuleBuilder<T, TProperty>
    {
        public RuleBuilder(PropertyRule<T, TProperty> rule)
        {
            Rule = rule;
        }

        public PropertyRule<T, TProperty> Rule { get; }

        public IRuleBuilder<T, TProperty> SetChecker(IPropertyChecker<T, TProperty> checker)
        {
            Rule.AddChecker(checker);

            return this;
        }
    }
}
