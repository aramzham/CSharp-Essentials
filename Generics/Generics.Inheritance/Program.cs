using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            SameDataLinkedList();

            Console.ReadKey();
        }

        static void SameDataLinkedList() 
        {
            var head = new NodeGeneric<char>('C');
            head = new NodeGeneric<char>('B', head);
            head = new NodeGeneric<char>('A', head);
            Console.WriteLine(head.ToString());
        }
    }
}
