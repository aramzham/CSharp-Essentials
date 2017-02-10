using System;
using System.Collections.Generic;

namespace DynamicArrays
{
    public class MyStack<T>
    {
        #region Constructors
        public MyStack() : this(0)
        {

        }

        public MyStack(int length)
        {
            if (length < 0) throw new ArgumentException();
            IEnumerable<T> obj = new T[length];
            list = new LinkedList<T>(obj);
        }

        public MyStack(IEnumerable<T> obj)
        {
            list = new LinkedList<T>(obj);
        }
        #endregion
        private LinkedList<T> list = new LinkedList<T>();

        //methods
        public void Push(T item)
        {
            list.AddLast(item);
        }

        public T Pop()
        {
            if (Count == 0) throw new InvalidOperationException();
            var temp = list.Last.Value;
            list.RemoveLast();
            return temp;
        }

        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException();
            return list.Last.Value;
        }

        public int Count => list.Count;
    }
}
