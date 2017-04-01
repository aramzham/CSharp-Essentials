using System;

namespace IList
{
    class Program
    {
        static void Main(string[] args)
        {
            var mc = new MyCollection { "Join", "us", "and", "you", "won't", "regret" };

            foreach (var item in mc)
            {
                Console.Write($"{item} ");
            }

            Console.ReadKey();
        }
    }
}
