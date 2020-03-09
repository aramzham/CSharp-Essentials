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

    internal sealed class SimpleType : IDisposable
    {
        public void Dispose() { Console.WriteLine("public Dispose"); }
        void IDisposable.Dispose() { Console.WriteLine("IDisposable Dispose"); }
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

            var simple = new SimpleType();
            simple.Dispose();

            // explicit interface method implementation(EIMI)
            var eimi = (IDisposable)simple;
            eimi.Dispose();

            Console.ReadKey();
        }
    }
}
