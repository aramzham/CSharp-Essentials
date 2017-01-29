using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method
{
    class Program
    {
        static void Main(string[] args)
        {
            Base bNotCasted = new Base();
            Base bCasted = new Derived();

            Console.WriteLine("------------- Base Class method calls ------------");
            bNotCasted.F1();
            bNotCasted.F2();
            bNotCasted.F3();
            bNotCasted.F4();
            bNotCasted.F5();

            Console.WriteLine("------------- Dervid Class casted to Base Class method calls -------------");
            bCasted.F1();
            bCasted.F2();
            bCasted.F3();
            bCasted.F4();
            bCasted.F5();

            Derived d = new Derived();

            Console.WriteLine("------------ Pure Derived Class method calls --------------");
            d.F1();
            d.F2();
            d.F3();
            d.F4();
            d.F5();

            Console.ReadKey();
        }
    }
}
