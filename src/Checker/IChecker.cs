namespace Checking.FluentApi
{
    public interface IChecker<T>
    {
        CheckResult Check(T instance);

        CheckResult Check(CheckContext<T> context);
    }
}
