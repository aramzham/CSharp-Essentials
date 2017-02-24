using System;
using System.Collections.Generic;
using System.Linq;

namespace Hash_table
{
    public class HashTableArray<TKey, TValue>
    {
        HashTableArrayNode<TKey, TValue>[] _array;  //creating node array  

        public HashTableArray(int capacity)
        {
            _array = new HashTableArrayNode<TKey, TValue>[capacity];
        }

        #region Getting the index of the node

        private int GetIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode() % Capacity);
        }

        #endregion

        #region Capacity of the array

        public int Capacity => _array.Length;

        #endregion

        #region Add an element

        public void Add(TKey key, TValue value)
        {

            int index = GetIndex(key);
            HashTableArrayNode<TKey, TValue> nodes = _array[index];

            if (nodes == null)
            {
                nodes = new HashTableArrayNode<TKey, TValue>();
                _array[index] = nodes;
            }

            nodes.Add(key, value);

        }
        #endregion

        #region Enumerators

        //public IEnumerable<TValue> Values 
        //{ 
        //    get 
        //    { 
        //        foreach (HashTableArrayNode<TKey, TValue> node in _array.Where(node => node != null)) 
        //        { 
        //            foreach (TValue value in node.Values) 
        //            { 
        //                yield return value; 
        //            } 
        //        } 
        //    } 
        //} 

        //public IEnumerable<TKey> Keys
        //{
        //    get
        //    {
        //        foreach (HashTableArrayNode<TKey, TValue> node in _array.Where(node => node != null))
        //        {
        //            foreach (TKey key in node.Keys)
        //            {
        //                yield return key;
        //            }
        //        }
        //    }
        //}

        public IEnumerable<HashTableNodePair<TKey, TValue>> Items
        {
            get
            {
                return _array.Where(node => node != null).SelectMany(node => node.Items);
            }
        }

        //public System.Collections.Generic.IEnumerator<HashTableNodePair<TKey, TValue>> GetEnumerator()
        //{

        //    foreach (HashTableArrayNode<TKey, TValue> node in _array.Where(node => node != null))
        //    {
        //        foreach (HashTableNodePair<TKey, TValue> pair in node.Items)
        //        {
        //            yield return pair;
        //        }
        //    }
        //}        

        #endregion

    }
}