using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicArrays
{
    class MyList<T> : IEnumerable
    {
        #region Constructors

        public MyList() : this(0)
        {

        }

        public MyList(int length)
        {
            if (length < 0) throw new ArgumentOutOfRangeException();

            array = new T[length];
        }

        public MyList(ICollection<T> collection)
        {
            var index = 0;
            var newArray = new T[collection.Count];
            foreach (var item in collection)
            {
                Count++;
                newArray[index++] = item;
            }
            array = newArray;
        }

        #endregion

        private T[] array;
        public int Count { get; set; }
        public int Capacity => array.Length;

        public int IndexOf(T item)
        {
            for (var i = 0; i < array.Length; i++)
                if (array[i].Equals(item)) return i;

            return -1;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException();
                return array[index];
            }
            set
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException();
                array[index] = value;
            }
        }   // indexer

        public void Add(T item)
        {
            if (Count == array.Length) GrowArray();

            array[Count++] = item;
        }

        private void GrowArray()
        {
            var newSize = array.Length == 0 ? 4 : array.Length * 2;
            var newArray = new T[newSize];
            Array.Copy(array, 0, newArray, 0, array.Length);
            array = newArray;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        } // a thing that i still don't understand :-)

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }
    }
}
