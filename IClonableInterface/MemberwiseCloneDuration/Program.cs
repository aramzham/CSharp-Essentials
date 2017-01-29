using System;
using System.Diagnostics;
using System.Threading;

namespace MemberwiseCloneTimer
{
    class Program
    {
        class MyClass : ICloneable
        {
            public MyClass()
            {
                Thread.Sleep(1000);
                var r1 = new Random().Next(1, 101); //some work
                Thread.Sleep(1000);
                var r2 = new Random().Next(1, 201); //some work
            }

            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }
        static void Main(string[] args)
        {
            var timer = new Stopwatch();

            timer.Start();
            var original = new MyClass();
            Console.WriteLine($"Ctor took {timer.ElapsedTicks} ticks");
            timer.Reset();

            timer.Start();
            var clone = original.Clone() as MyClass;
            Console.WriteLine($"MemberwiseClone took {timer.ElapsedTicks} ticks");

            //there is no doubt that MemberwiseClone() is faster and that it doesn't use any ctor for cloning

            Console.ReadKey();
        }
    }
}
