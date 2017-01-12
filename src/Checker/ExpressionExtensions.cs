using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Checking.FluentApi
{
    internal static class ExpressionExtensions
    {
        public static MemberInfo GetMember(this LambdaExpression expression)
        {
            var memberExp = RemoveUnary(expression.Body);

            if (memberExp == null)
            {
                return null;
            }

            return memberExp.Member;
        }

        public static MemberInfo GetMember<T, TProperty>(this Expression<Func<T, TProperty>> expression)
        {
            var memberExp = RemoveUnary(expression.Body);

            if (memberExp == null)
            {
                return null;
            }

            return memberExp.Member;
        }

        private static MemberExpression RemoveUnary(Expression toUnwrap)
        {
            if (toUnwrap is UnaryExpression)
            {
                return ((UnaryExpression)toUnwrap).Operand as MemberExpression;
            }

            return toUnwrap as MemberExpression;
        }
    }
}
