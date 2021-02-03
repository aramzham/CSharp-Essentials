using System;
using System.Linq.Expressions;
using _Common_Expressions;

namespace _03_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = new Student() { Name = "A1", Age = 18 };

            //Func<Student, bool> isTeenager = s => s.Age > 12 && s.Age < 20;
            ParameterExpression pe1 = Expression.Parameter(typeof(Student), "s");

            Expression<Func<Student, bool>> isTeenagerExpression = Expression.Lambda<Func<Student, bool>>(
                Expression.AndAlso(
                    Expression.GreaterThan(Expression.Property(pe1, "Age"), Expression.Constant(12, typeof(int))),
                    Expression.LessThan(Expression.Property(pe1, "Age"), Expression.Constant(20, typeof(int)))),
                new[] { pe1 });

            var isTeenager1 = isTeenagerExpression.Compile();
            Console.WriteLine(isTeenager1(st) ? "Yes" : "No");

            Console.ReadKey();
        }
    }
}
