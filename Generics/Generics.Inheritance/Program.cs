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
            DifferentDataLinkedList();
            
            Console.ReadKey();
        }

        static void SameDataLinkedList() 
        {
            var head = new NodeGeneric<char>('C');
            head = new NodeGeneric<char>('B', head);
            head = new NodeGeneric<char>('A', head);
            Console.WriteLine(head.ToString());
        }

        static void DifferentDataLinkedList() 
        {
            NodeNonGeneric head = new TypedNode<char>('.');
            head = new TypedNode<DateTime>(DateTime.Now, head);
            head = new TypedNode<string>("Today is ", head);
            Console.WriteLine(head.ToString());
        }
    }
}
