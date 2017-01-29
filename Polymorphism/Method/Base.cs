using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method
{
    class Base
    {
        public virtual void F1()
        {
            Console.WriteLine("Base F1 is called");
        }
        public virtual void F2()
        {
            Console.WriteLine("Base F2 is called");
        }
        public virtual void F3()
        {
            Console.WriteLine("Base F3 is called");
        }
        public void F4()
        {
            Console.WriteLine("Not virtual F4 base method is called");
        }
        public void F5()
        {
            Console.WriteLine("Not virtual F5 base method is called");
        }
    }
}
