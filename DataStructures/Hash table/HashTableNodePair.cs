namespace Hash_table
{
    public class HashTableNodePair<TKey, TValue>
    {
        public HashTableNodePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        // you cannot change the key, it'll change the indexation of the table
        public TKey Key { get; private set; }
        public TValue Value { get; set; }
    }
}