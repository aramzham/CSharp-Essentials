using System;
using System.Threading.Tasks;

namespace EssentialTypes.Arrays.ArrayList
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var array = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (var element in array)
            {
                Array.Reverse(array); // we can change collection in foreach only with arrays
                Console.WriteLine(element);
            }

            var arrayList = new System.Collections.ArrayList() { 32, new MyClass(), 3.14f };
            foreach (var element in arrayList)
            {
                // arrayList.Reverse(); // will crash here

                if (element is MyClass myClass)
                    myClass.Modify();

                arrayList.Capacity = 10; // in .net 1 you could change the capacity, then in .net 2 they couldn't change this feature

                Console.WriteLine(element);

                arrayList.Capacity = 4;
            }

            Console.ReadKey();
        }
    }

    class MyClass
    {
        private int _state;

        public void Modify() => _state++;

        public override string ToString() => $"MyClass({_state})";
    }
}
