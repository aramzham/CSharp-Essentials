using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialTypes.Strings.StringBuilders
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder(1,2);
            Console.WriteLine($"Max capacity = {sb.MaxCapacity}");
            Console.WriteLine($"Capacity = {sb.Capacity}");

            sb.Append('1');
            sb.Append('2');
            //sb.Append('3');
            Console.WriteLine($"sb[0] = {sb[0]}");
            Console.WriteLine($"sb.Length = {sb.Length}");
            Console.WriteLine($"sb.Length > sb.Capacity = {sb.Length > sb.Capacity}");
        }
    }
}
