using System;
using System.Linq.Expressions;
using _Common_Expressions;

namespace _01_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = new Student() { Name = "A1", Age = 18 };

            Func<Student, bool> isTeenager = s => s.Age > 12 && s.Age < 20;
            Expression<Action<Student>> expression = student => Console.WriteLine(student.Name);
            var action = expression.Compile();
            action(st);
            Console.WriteLine(isTeenager(st) ? "Yes" : "No");

            Console.ReadKey();
        }
    }
}
