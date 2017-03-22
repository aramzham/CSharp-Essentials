using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQToObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = new object[] { "1", "2", "3", "AAA", 5 };
            //IEnumerable<string> strings = values.Cast<string>();//cannot cast int to string => exception
            //IEnumerable<string> strings = from string x in values //sql style
            //select x;               //it won't work either

            IEnumerable<string> strings = values.OfType<string>(); //filters the elements based on specified type => so the last int will be omitted

            var objects = new object[] { "1", "2", "3", "AAA", 5, "AAB" };
            IEnumerable<string> result = objects.OfType<string>().Where(i => i.StartsWith("A")); //we take all the strings and filter whether there are ones that start with "A"

            var example = new[] { "1", "AAA", "3", "2", "ABB" };
            string first = example.Where(i => i.StartsWith("A")).First(); //takes the first element of the query
            string last = example.Where(i => i.StartsWith("A")).Last(); //takes the last one
            //both will throw exceptions if collection doesn't contain any element
            Console.WriteLine($"First = {first}");
            Console.WriteLine($"Last = {last}");
            string otherFirst = example.First(i => i.StartsWith("A")); //we'll get the same result
            string otherLast = example.Last(i => i.StartsWith("A"));
            Console.WriteLine($"Is other first the same as first? : {first.Equals(otherFirst)}");
            Console.WriteLine($"Is other last the same as last?: {last.Equals(otherLast)}");

            //this one works as the previous but if there is no element in container it will return the default value of the type
            string firstOrDefault = example.Where(i => i.StartsWith("A")).FirstOrDefault();
            Console.WriteLine($"In this case First() and FirstOrDefault() give the same result?: {first.Equals(firstOrDefault)}");
            string lastOrDefault = example.LastOrDefault(i => i.StartsWith("A"));
            Console.WriteLine($"In this case Last() and LastOrDefault() give the same result?: {last.Equals(lastOrDefault)}");

            bool any = example.Any(i => i.StartsWith("A")); //we want to know if any element of collection satisfys the condition
            Console.WriteLine($"Is there any element starting with \"A\"?: {any}");

            bool containsAnyElement = example.Any(); //this will check if there is any element in the collection
            Console.WriteLine($"Is there any element in the collection?: {containsAnyElement}");

            bool all = example.All(i => i.StartsWith("A")); //this will check whether all elements start with "A"
            Console.WriteLine($"Do all elements start with \"A\"?: {all}");

            int count = example.Count(i => i.StartsWith("A")); //it will return the count of elements satisfying specified condition
            Console.WriteLine($"We have {count} elements starting with \"A\"");
            int getCount = example.Count(); //we can also get the count of all elements but it's not the best practice
            Console.WriteLine($"Length of array is {getCount}");

            IEnumerable<string> orderedAsc = example.OrderBy(i => i.Length); //order by length in asceding order(set by default)
            IEnumerable<string> orderedDesc = example.OrderByDescending(i => i.Length); //order by descending order
            IEnumerable<string> thenBy = example.OrderBy(i => i.Length).ThenBy(i => i); //sorts by length, then sorts by values
            IEnumerable<string> thenBySQL = from x in example           //same result, no difference
                                            orderby x.Length, x
                                            select x;

            var array = new[] { "1", "1", "2", "2", "3", "3", "3" };
            IEnumerable<string> distinct = array.Distinct(); //removes duplicates from collection
            var letters = new[] { "A", "B", "b", "C", "C", "c", "C" };
            IEnumerable<string> distinctLetters = letters.Distinct(StringComparer.OrdinalIgnoreCase); //removed ignoring the case

            IEnumerable<string> reversed = letters.Reverse(); //reverses the collection

            foreach (var s in reversed)
            {
                Console.Write($"{s}\t");
            }

            Console.ReadKey();
        }
    }
}
