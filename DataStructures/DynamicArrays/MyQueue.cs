using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArrays
{
   public class MyQueue<T>
    {
        #region Constructors
        public MyQueue() : this(0)
        {
            
        }

        public MyQueue(int length)
        {
            if(length<0) throw new ArgumentException();
            IEnumerable<T> obj = new T[length];
            list = new LinkedList<T>(obj);
        }

        public MyQueue(IEnumerable<T> obj)
        {
            list = new LinkedList<T>(obj);
        }
#endregion

        private LinkedList<T> list = new LinkedList<T>();

        public void Enqueue(T item)
        {
            list.AddFirst(item);
        }

        public T Dequeue()
        {
            if (Count==0) throw new InvalidOperationException();
            var temp = list.First.Value;
            list.RemoveFirst();
            return temp;
        }

        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException();
            return list.First.Value;
        }

        public int Count => list.Count;
    }
}
