using System.Collections.Generic;

namespace Checking.FluentApi
{
    public interface ICheckRule<T>
    {
        IEnumerable<CheckFailure> Check(CheckContext<T> context);
    }
}
