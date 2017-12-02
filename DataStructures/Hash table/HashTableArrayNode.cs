using System;
using System.Collections.Generic;

namespace Hash_table
{
    public class HashTableArrayNode<TKey, TValue>
    {

        LinkedList<HashTableNodePair<TKey, TValue>> _items;

        #region Add a new node (key-value pair)

        public void Add(TKey key, TValue value)
        {
            //we create a table on a double linked list basis
            if (_items == null)
            {
                _items = new LinkedList<HashTableNodePair<TKey, TValue>>();
            }
            else
            {
                //keys must be unique

                foreach (HashTableNodePair<TKey, TValue> pair in _items)
                {
                    // if such key exists, throw an exception

                    if (pair.Key.Equals(key)) throw new ArgumentException("Such key already exists");
                }
            }

            // adding a new node.     
            _items.AddLast(new HashTableNodePair<TKey, TValue>(key, value));
        }

        #endregion

        #region Update by key

        public void Update(TKey key, TValue value)
        {
            bool updated = false;

            if (_items != null)
            {
                foreach (HashTableNodePair<TKey, TValue> pair in _items)
                {
                    if (pair.Key.Equals(key))
                    {
                        // rewrite the value
                        pair.Value = value;
                        updated = true;
                        break;
                    }
                }
            }

            if (!updated) throw new ArgumentException("Key couldn't be found");
        }

        #endregion

        #region Search by key

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);
            bool found = false;

            if (_items != null)
            {
                foreach (HashTableNodePair<TKey, TValue> pair in _items)
                {
                    if (pair.Key.Equals(key))
                    {
                        value = pair.Value;
                        found = true;
                        break;
                    }
                }
            }
            return found;
        }

        #endregion

        #region Remove item by key

        public bool Remove(TKey key)
        {
            bool removed = false;
            if (_items != null)
            {
                LinkedListNode<HashTableNodePair<TKey, TValue>> current = _items.First;

                while (current != null)
                {
                    if (current.Value.Key.Equals(key))
                    {
                        _items.Remove(current);
                        removed = true; break;
                    }
                    current = current.Next;
                }
            }
            return removed;
        }
        #endregion

        #region Remove all the elements from list

        public void Clear()
        {
            _items?.Clear();
        }

        #endregion

        #region Enumerators

        //public IEnumerable<TValue> Values
        //{
        //    get
        //    {
        //        if (_items != null)
        //        {
        //            foreach (HashTableNodePair<TKey, TValue> node in _items)
        //            {
        //                yield return node.Value;
        //            }
        //        }
        //    }
        //} 

        //public IEnumerable<TKey> Keys
        //{
        //    get
        //    {
        //        if (_items != null)
        //        {
        //            foreach (HashTableNodePair<TKey, TValue> node in _items)
        //            {
        //                yield return node.Key;
        //            }
        //        }
        //    }
        //}

        public IEnumerable<HashTableNodePair<TKey, TValue>> Items
        {
            get
            {
                if (_items != null)
                {
                    foreach (HashTableNodePair<TKey, TValue> node in _items)
                    {
                        yield return node;
                    }
                }
            }
        }

        #endregion
    }
}