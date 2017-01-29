using System;

namespace NoAssociationCopy
{
    class A { public int a = 1; }
    class B { public int b = 2; }

    class C
    {
        public A A = new A();
        public B B = new B();
    }

    class X : C, ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{this.A.a} {this.B.b}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var original = new X();
            Console.WriteLine($"Original {original}");

            var clone = original.Clone() as X;
            Console.WriteLine($"Clone {clone}");

            clone.A.a = clone.B.b = 7;
            //in this case the clone goes by reference and changes the values of A.a and B.b in original
            Console.WriteLine($"Original {original}");
            Console.WriteLine($"Clone {clone}");

            Console.ReadKey();
        }
    }
}
