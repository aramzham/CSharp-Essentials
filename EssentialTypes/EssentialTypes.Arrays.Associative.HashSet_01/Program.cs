using System;
using System.Collections.Generic;

namespace EssentialTypes.Arrays.Associative.HashSet_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new HashSet<MyType>(4); // slot length will be 3 (default) * 2 and nearest prime = 7 => 2 and 9 will collide as 2 % 7 = 2 and 9 % 7 = 2
            set.Add(new MyType(){HashCode = 1});
            set.Add(new MyType(){HashCode = 8});
            set.Add(new MyType(){HashCode = 2});
            set.Add(new MyType(){HashCode = 3});
            set.Add(new MyType(){HashCode = 9});

            set.Remove(new MyType() {HashCode = 1});
            set.Remove(new MyType() {HashCode = 3});
            Console.WriteLine(set.Count);

            set.Add(new MyType() {HashCode = -1});

            Console.ReadKey();
        }
    }

    class MyType
    {
        public int HashCode { get; set; } = 1;

        public override int GetHashCode()
        {
            return HashCode;
        }

        public override bool Equals(object? obj)
        {
            return obj is MyType other && other.HashCode == this.HashCode;
        }
    }
}
