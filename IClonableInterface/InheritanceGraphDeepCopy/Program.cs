using System;

namespace Dolly
{
    class A { public int a = 1; }
    class B : A { public int b = 2; }
    class C : B { public int c = 3; }
    class X : C, ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var original = new X();
            Console.WriteLine($"Original values {original.a} {original.b} {original.c}");

            var clone = (X)original.Clone();
            clone.a = clone.b = clone.c = 7;
            Console.WriteLine($"We have changed all the values of clone {clone.a} {clone.b} {clone.c}");

            Console.ReadKey();
        }
    }
}
