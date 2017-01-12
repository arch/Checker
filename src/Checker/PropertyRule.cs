using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Checking.FluentApi
{
    public class PropertyRule<T, TProperty> : ICheckRule<T>
    {
        private readonly IList<IPropertyChecker<T, TProperty>> checkers = new List<IPropertyChecker<T, TProperty>>();

        public PropertyRule(MemberInfo member, Func<T, TProperty> propertyFunc, LambdaExpression expression, Type typeToValidate)
        {
            Member = member;
            PropertyFunc = propertyFunc;
            Expression = expression;
            TypeToValidate = typeToValidate;
        }

        public static PropertyRule<T, TProperty> Create(Expression<Func<T, TProperty>> expression)
        {
            var member = expression.GetMember();

            var compiled = expression.Compile();

            return new PropertyRule<T, TProperty>(member, compiled, expression, typeof(TProperty));
        }

        public MemberInfo Member { get; }

        public Func<T, TProperty> PropertyFunc { get; }

        public LambdaExpression Expression { get; }

        public IPropertyChecker<T, TProperty> CurrentChecker { get; private set; }

        /// <summary>
        /// Type of the property being validated
        /// </summary>
        public Type TypeToValidate { get; private set; }

        public IEnumerable<IPropertyChecker<T, TProperty>> Checkers => checkers;

        public IEnumerable<CheckFailure> Check(CheckContext<T> context)
        {
            foreach (var checker in checkers)
            {
                var hasFailure = false;
                var failures = checker.Checker(new PropertyCheckContext<T, TProperty>(context, this, Member.Name));

                foreach (var item in failures)
                {
                    hasFailure = true;
                    yield return item;
                }

                if (hasFailure)
                {
                    break;
                }
            }
        }

        public void AddChecker(IPropertyChecker<T, TProperty> checker)
        {
            CurrentChecker = checker;

            checkers.Add(checker);
        }
    }
}
