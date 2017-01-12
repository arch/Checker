namespace Checking.FluentApi
{
    public interface IRuleBuilder<T, TProperty>
    {
        IRuleBuilder<T, TProperty> SetChecker(IPropertyChecker<T, TProperty> checker);
    }
}
