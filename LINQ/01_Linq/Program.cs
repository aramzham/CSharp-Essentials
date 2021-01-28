using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var randoms = RandomGenerator(); // 100 ints in range of 0 to 1000
            var odds = randoms.MyFind(x => x % 2 == 1);
            var two = randoms.MyTake(2).ToList();
            var groups = randoms.MyGroupBy(x => x % 3);
            var linqGroups = randoms.GroupBy(x => x % 3);
            var linqToLookup = randoms.ToLookup(x => x % 3);

            Console.ReadKey();
        }

        static IEnumerable<int> RandomGenerator()
        {
            var r = new Random();
            for (int i = 0; i < 100; i++)
            {
                yield return r.Next(0, 1001);
            }
        }
    }
}
