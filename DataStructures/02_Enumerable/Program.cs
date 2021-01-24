using System;
using System.Collections;
using System.Reflection.Metadata;

namespace _02_Enumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            var rootNode = new ListNode() { Value = 10 };
            rootNode.Add(20).Add(30);

            #region Iterator pattern

            var enumerator = rootNode.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    var item = enumerator.Current;
                    Console.WriteLine(item);
                }
            }
            finally
            {
                enumerator.Reset();
            }

            #endregion

            // compiler will look for a GetEnumerator function
            foreach (var node in rootNode)
            {
                
            }

            Console.ReadKey();
        }
    }

    public class ListNode : IEnumerable // this inheritance is not obligatory
    {
        public int Value { get; set; }
        private ListNode _next;
        private ListNode _last;

        public ListNode Add(int value)
        {
            _next = new ListNode() { Value = value };
            return _next;
        }

        public override string ToString()
        {
            return $"{Value}, next: {_next?.Value}";
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        private class Enumerator : IEnumerator
        {
            private ListNode _node;

            public object? Current { get; private set; }

            public Enumerator(ListNode node)
            {
                _node = node;
            }

            public bool MoveNext()
            {
                if (_node is null)
                    return false;

                Current = _node;
                _node = _node._next;
                return true;
            }

            public void Reset()
            {
                _node = null;
            }
        }
    }
}
