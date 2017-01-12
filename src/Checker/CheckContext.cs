namespace Checking.FluentApi
{
    public class CheckContext<T>
    {
        public CheckContext(T instance)
        {
            InstanceToCheck = instance;
        }

        public T InstanceToCheck { get; }
    }
}
