using System;
using System.Linq.Expressions;
using _Common_Expressions;

namespace _07_Expressions_Copy
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = new Student() { Age = 19, Name = "Vahram" };
            Expression<Func<Student, Student>> copyExpression = student => new Student() { Age = student.Age, Name = student.Name };
            Func<Student, Student> copyFunc = copyExpression.Compile();

            var clone = copyFunc(st);
            Console.WriteLine($"{clone.Age}, {clone.Name}");

            Console.ReadKey();
        }
    }
}
