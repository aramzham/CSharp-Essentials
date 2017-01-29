using System;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var yourNumber = 10;
            var delarray = new RandomHandler[yourNumber].Select(x=>new RandomHandler(GiveMeSomeRandomNumber)).ToArray();
            
            var ah = new AverageHandler(AverageOfDelegateMassive);

            Console.WriteLine(ah.Invoke(delarray));

            Console.ReadKey();
        }

        public static double AverageOfDelegateMassive(RandomHandler[] delegateArray)
        {
            return delegateArray.Select(x => x.Invoke()).Average();
        }

        public static int GiveMeSomeRandomNumber()
        {
            return new Random().Next(0,101);
        }

        public delegate int RandomHandler();

        public delegate double AverageHandler(RandomHandler[] rharray);
    }
}
