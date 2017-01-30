using System;
using System.Collections;
using System.Linq;

namespace DynamicArrays
{
    class Program
    {

        public static void Print(IEnumerable obj)
        {
            foreach (var item in obj)
                Console.Write($"{item} ");
        }
        static void Main(string[] args)
        {
            var words = new[] { "I", "see", "no", "changes.", "Woke", "up", "in", "the", "morning", "and", "asked", "myself" };
            var myArray = new MyList<string>(words);
            Print(myArray);
            Console.WriteLine("\n" + myArray.IndexOf("now"));
            Console.WriteLine(myArray.Contains("the"));
            Console.WriteLine(words[5]);
            words[11] = "yourself";
            //Console.WriteLine(words[12]); words[-1] = "something";  // this two cases bring exceptions
            Print(myArray);

            var anotherArray = new MyList<int>();
            anotherArray.Add(1);
            anotherArray.Add(1);
            anotherArray.Add(1);
            anotherArray.Add(1);
            anotherArray.Add(1);
            Console.WriteLine(anotherArray.Capacity);

            var stack = new MyStack<string>();
            stack.Push("push me");
            stack.Push("and then just");
            stack.Push("touch me");
            Console.WriteLine(stack.Peek());
            stack.Pop();
            Console.WriteLine(stack.Peek());

            var queue = new MyQueue<int>(5);
            Console.WriteLine(queue.Count);
            queue.Enqueue(1);
            queue.Enqueue(10);
            queue.Enqueue(100);
            queue.Enqueue(1000);
            queue.Enqueue(10000);
            queue.Enqueue(100000);
            Console.WriteLine(queue.Count);
            queue.Dequeue();
            Console.WriteLine(queue.Peek());

            Console.ReadKey();
        }
    }
}
