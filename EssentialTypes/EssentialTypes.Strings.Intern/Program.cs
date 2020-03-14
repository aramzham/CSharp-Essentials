using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialTypes.Strings.Intern
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = "Hello";
            var s2 = "Hello";
            Console.WriteLine(ReferenceEquals(s1, s2)); // should be False, but my clr gives True

            s1 = string.Intern(s1);
            s2 = string.Intern(s2);
            Console.WriteLine(ReferenceEquals(s1, s2)); // True

            Console.ReadKey();
        }
    }
}
