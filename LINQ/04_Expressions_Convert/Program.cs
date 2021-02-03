using System;
using System.Linq.Expressions;

namespace _04_Expressions_Convert
{
    class Program
    {
        static void Main(string[] args)
        {
            // converting string to int
            var mi = typeof(Convert).GetMethod("ToInt32", new[] { typeof(string) });

            var par = Expression.Parameter(typeof(string), "<p>"); // <> means that it's my parameter, just a convention for myself
            var convertExp = Expression.Convert(par, typeof(int), mi);
            var toInt32Exp = Expression.Lambda<Func<string, int>>(convertExp, par);

            Func<string, int> toInt32 = toInt32Exp.Compile();
            var a = toInt32("10");
            Console.WriteLine(a);

            Console.ReadKey();
        }
    }
}
