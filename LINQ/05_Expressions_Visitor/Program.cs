using System;
using System.Linq.Expressions;
using _Common_Expressions;

namespace _05_Expressions_Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = new Student() { Name = "A1", Age = 18 };

            Expression<Func<Student, bool>> q1 = s1 => s1.Age > 12;
            Expression<Func<Student, bool>> q2 = s2 => s2.Age < 20;

            BinaryExpression andExpression = Expression.AndAlso(q1.Body, q2.Body);
            var parExp = Expression.Parameter(typeof(Student), "p");

            // Use visitor
            var visitedBody = new ParameterReplacer(parExp).Visit(andExpression);
            //Expression<Func<Student, bool>> isTeenagerExp = Expression.Lambda<Func<Student, bool>>(andExpression, parExp); // won't work
            Expression<Func<Student, bool>> isTeenagerExp = Expression.Lambda<Func<Student, bool>>(visitedBody, parExp);

            Console.WriteLine(isTeenagerExp);
            var isTeenager2 = isTeenagerExp.Compile();

            Console.WriteLine(isTeenager2(st) ? "Yes" : "No");

            Console.ReadKey();
        }
    }
}
