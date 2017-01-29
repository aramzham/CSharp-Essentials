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

            Console.ReadKey();
        }
    }
}
