using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.TestConsole
{
    interface IInterface
    {
        // If you do not explicitly mark the method as virtual in your source code, 
        // the compiler marks the method as virtual and sealed; 
        // this prevents a derived class from overriding the interface method
        void InterfaceMethod();
    }

    class MyClass : IInterface
    {
        public void InterfaceMethod()
        {
            throw new NotImplementedException();
        }
    }

    class Base : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Dispose in base class");
        }
    }

    class Derived : Base, IDisposable
    {
        public new void Dispose()
        {
            Console.WriteLine("Dispose in derived class");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var myClass = new MyClass();
            var inter = (IInterface)myClass;
            // how many methods are there in inter?

            var b = new Base();
            b.Dispose();

            var d = new Derived();
            ((IDisposable)d).Dispose();

            Console.ReadKey();
        }
    }
}
