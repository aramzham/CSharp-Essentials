using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.ReadKey();
        }

        static void CompareThrowingError()
        {
            int x = 1, y = 2;
            IComparable c = x; // boxing

            Console.WriteLine(c.CompareTo(y)); // y is boxed, no error

            Console.WriteLine(c.CompareTo("1990")); // runtime error
        }

        static void CompareNotThrowing()
        {
            int x = 1, y = 2;
            IComparable<int> c = x;

            c.CompareTo(y); // no boxing

            // c.CompareTo("100"); // won't compile
        }

        /// <summary>
        /// ■ Undesired boxing When v is passed as an argument to the CompareTo method, it must be boxed because CompareTo expects an Object.        ■ The lack of type safety This code compiles, but an InvalidCastException is thrown inside the CompareTo method when it attempts to cast o to SomeValueType
        /// </summary>
        static void NotIdealCode()
        {
            var v = new SomeValueType(0);
            var o = new object();

            var n = v.CompareTo(v); // boxing of value type
            n = v.CompareTo(o); // invalid cast exception
        }

        static void IdealCode() 
        {
            var v = new ValueTypeWithEimi(1);
            var o = new object();
            var n = v.CompareTo(v); // no boxing as CompareTo(ValueTypeWithEimi other) will be called
            // n = v.CompareTo(o); // compile time error
        }
    }

    internal struct ValueTypeWithEimi : IComparable
    {
        private int m_x;
        public ValueTypeWithEimi(int x) { m_x = x; }

        public int CompareTo(ValueTypeWithEimi other) => m_x - other.m_x;

        // An EIMI cannot be called by a derived type. Derived can't even call it by base.()
        int IComparable.CompareTo(object obj) => CompareTo((ValueTypeWithEimi)obj);
        // another problem with eimi is that you see that type implements interface, but you can't call the method
    }

    public struct SomeValueType : IComparable
    {
        private int _value;

        public SomeValueType(int value)
        {
            _value = value;
        }

        public int CompareTo(object obj)
        {
            return _value.CompareTo((int)obj);
        }
    }
}
