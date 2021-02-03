using System;
using System.Linq.Expressions;
using _Common_Expressions;

namespace _02_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // creating an expression    s => s.Age >= 18
            ParameterExpression pe = Expression.Parameter(typeof(Student), "s");

            MemberExpression meAge = Expression.Property(pe, "Age");
            ConstantExpression constant18 = Expression.Constant(18, typeof(int));
            BinaryExpression body = Expression.GreaterThanOrEqual(meAge, constant18);

            var isAdultExprTree = Expression.Lambda<Func<Student, bool>>(body, new[] { pe });

            Console.WriteLine($"Expression Tree: {isAdultExprTree}");
            Console.WriteLine($"Expression Tree Body: {isAdultExprTree.Body}");
            Console.WriteLine($"Number of Parameters Expression Tree: {isAdultExprTree.Parameters.Count}");
            Console.WriteLine($"Parameters in Expression Tree: {isAdultExprTree.Parameters[0]}");

            Console.ReadKey();
        }
    }
}
