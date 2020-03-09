using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.TestConsole
{
    interface IInterface
    {
        void InterfaceMethod();
    }

    class MyClass : IInterface
    {
        public void InterfaceMethod()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var myClass = new MyClass();
            var inter = (IInterface)myClass;
            // how many methods are there in inter?
        }
    }
}
