using System;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<int>();

            tree.Add(10);
            tree.Add(6);
            tree.Add(15);
            tree.Add(8);
            tree.Add(20);
            tree.Add(4);

            foreach (var node in tree)
            {
                Console.WriteLine(node);
            }
        }
    }
}
