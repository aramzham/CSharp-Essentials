using System;

namespace Hash_table
{
    public class HashTable<TKey, TValue>
    {
        //if the array is filled by 75% - array we'll be increased

        const double _fillFactor = 0.75;

        // max element count

        int _maxItemsAtCurrentSize;

        // count of the elements of our hash table
        int _count;

        // array where we'll put our values   

        HashTableArray<TKey, TValue> _array;

        public HashTable() : this(1000)
        {
        }

        // master ctor

        public HashTable(int initialCapacity)
        {
            if (initialCapacity < 1)
            {
                throw new ArgumentOutOfRangeException("Given size is less than 1");
            }

            _array = new HashTableArray<TKey, TValue>(initialCapacity);

            // Increasing the size of the array

            _maxItemsAtCurrentSize = (int)(initialCapacity * _fillFactor) + 1;

        }
        #region Add an element into hash table

        public void Add(TKey key, TValue value)
        {

            if (_count >= _maxItemsAtCurrentSize)
            {
                // Increasing the capacity
                HashTableArray<TKey, TValue> largerArray = new HashTableArray<TKey, TValue>(_array.Capacity * 2);

                // copying the values to the new array         
                foreach (HashTableNodePair<TKey, TValue> node in _array.Items)
                {
                    largerArray.Add(node.Key, node.Value);
                }

                _array = largerArray;

                _maxItemsAtCurrentSize = (int)(_array.Capacity * _fillFactor) + 1;
            }

            _array.Add(key, value);
            _count++;
        }
        #endregion

        #region Enumerator

        public System.Collections.Generic.IEnumerator<HashTableNodePair<TKey, TValue>> GetEnumerator()
        {
            return _array.Items.GetEnumerator();
        }

        #endregion

        #region Elements count

        public int Count => _count;

        #endregion
    }
}