using System;
using System.Linq.Expressions;

namespace _Common_Expressions
{
    public static class Extensions
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right) => Compose(left, right, Expression.AndAlso);

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right) => Compose(left, right, Expression.OrElse);

        private static Expression<T> Compose<T>(Expression<T> left, Expression<T> right, Func<Expression, Expression, Expression> merge)
        {
            var mergeExp = merge(left.Body, right.Body);
            var body = new ParameterReplacer(left.Parameters).Visit(mergeExp);

            // apply composition of lambda expression bodies to parameters from the first expression.
            return Expression.Lambda<T>(body, left.Parameters);
        }
    }
}