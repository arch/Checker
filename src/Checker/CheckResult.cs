using System.Collections.Generic;
using System.Linq;

namespace Checking.FluentApi
{
    public class CheckResult
    {
        private readonly IList<CheckFailure> errors;

        public bool Succeed => errors.Count == 0;

        public IList<CheckFailure> Errors => errors;

        public CheckResult()
        {
            errors = new List<CheckFailure>();
        }

        public CheckResult(IEnumerable<CheckFailure> failures)
        {
            errors = failures.ToList();
        }
    }
}
