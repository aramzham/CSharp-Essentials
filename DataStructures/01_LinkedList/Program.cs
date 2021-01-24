using System;

namespace _01_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var rootNode = new Node() {Value = 10};
            rootNode.Add(20).Add(30).Add(40);
            Console.WriteLine(rootNode);

            Console.ReadKey();
        }
    }

    class Node
    {
        public int Value { get; set; }
        private Node _next;

        public Node Add(int value)
        {
            _next = new Node() { Value = value };
            return _next;
        }

        public override string ToString() => $"{Value}, next: {_next?.Value}";
    }
}
