using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method
{
    class Derived : Base
    {
        public override void F1()
        {
            Console.WriteLine("Derived F1 is called");
        }
        public new void F2()
        {
            Console.WriteLine("Derived F2 is called with new");
        }
        public void F3()
        {
            Console.WriteLine("Derived F3 is called without a keyword");
        }
        public new void F4()
        {
            Console.WriteLine("Derived F4 with new is called");
        }
        public void F5()
        {
            Console.WriteLine("Derived F5 is called with same name and without keyword");
        }
    }
}
