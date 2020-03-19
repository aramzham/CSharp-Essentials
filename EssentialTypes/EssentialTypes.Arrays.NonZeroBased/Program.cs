using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialTypes.Arrays.NonZeroBased
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Array.CreateInstance(typeof(int), new Int32[] { 10 }, new Int32[] { 1 });
            a.SetValue(3000, 2);
            Console.WriteLine(a.GetValue(2));
            Console.WriteLine(a.GetValue(0)); // will throw out of bounds excpetion

            // Create the array.
            Array myArray = Array.CreateInstance(typeof(double), new int[1] { 12 }, new int[1] { 1 });

            // Fill the array with random values.
            Random rand = new Random();
            for (int index = myArray.GetLowerBound(0); index <= myArray.GetUpperBound(0); index++)
            {
                myArray.SetValue(rand.NextDouble(), index);
            }

            // Display the values.
            for (int index = myArray.GetLowerBound(0); index <= myArray.GetUpperBound(0); index++)
            {
                Console.WriteLine("myArray[{0}] = {1}", index, myArray.GetValue(index));
            }
        }
    }
}
