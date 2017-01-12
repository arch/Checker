using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Checking.FluentApi
{
    public abstract class CheckerBase<T> : IChecker<T>
    {
        private readonly IList<ICheckRule<T>> rules = new List<ICheckRule<T>>();

        public virtual CheckResult Check(CheckContext<T> context)
        {
            var failures = rules.SelectMany(r => r.Check(context));

            return new CheckResult(failures);
        }

        public virtual CheckResult Check(T instance)
        {
            return Check(new CheckContext<T>(instance));
        }

        public void AddRule(ICheckRule<T> rule)
        {
            rules.Add(rule);
        }

        public IRuleBuilder<T, TProperty> RuleFor<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            var rule = PropertyRule<T, TProperty>.Create(expression);

            AddRule(rule);

            return new RuleBuilder<T, TProperty>(rule);
        }
    }
}
