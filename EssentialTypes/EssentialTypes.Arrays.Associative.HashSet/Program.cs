using System;
using System.Collections.Generic;

namespace EssentialTypes.Arrays.Associative.HashSet
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new MyClass();
            var set = new HashSet<MyClass>();
            set.Add(m);
            Console.WriteLine($"m is in set = {set.Contains(m)}");
            m.SetState(1);
            Console.WriteLine($"m is in set after modify = {set.Contains(m)}");

            var otherM = new MyClass();
            otherM.SetState(1);
            Console.WriteLine($"m.HashCode == otherM.HashCode = {m.GetHashCode() == otherM.GetHashCode()}");
            Console.WriteLine($"is other m in set = {set.Contains(otherM)}");

            Console.ReadKey();
        }
    }

    class MyClass
    {
        private int _state;

        public void SetState(int value)
        {
            _state = value;
        }

        public override string ToString() => $"MyClass({_state})";

        public override int GetHashCode() => _state; //HashCode.Combine(_state);
    }
}
