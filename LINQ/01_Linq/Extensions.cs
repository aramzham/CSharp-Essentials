using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Linq
{
    public static class Extensions
    {
        public static IEnumerable<T> MyFind<T>(this IEnumerable<T> source, Func<T, bool> predicateFunc)
        {
            foreach (var item in source)
            {
                if(predicateFunc.Invoke(item))
                    yield return item;
            }
        }

        public static IEnumerable<T> MyTake<T>(this IEnumerable<T> source, int count)
        {
            if (count <= 0) 
                yield break;

            foreach (var item in source)
            {
                if (count == 0)
                    yield break;
                else
                    yield return item;
                
                count--;
            }
        }

        public static IEnumerable<IGrouping<TKey, TValue>> MyGroupBy<TKey, TValue>(this IEnumerable<TValue> source,
            Func<TValue, TKey> keySelector)
        {   
            var dict = new Dictionary<TKey, Grouping<TKey, TValue>>();
            foreach (var item in source)
            {
                var key = keySelector.Invoke(item);
                if (!dict.TryGetValue(key, out var group))
                {
                    group = new Grouping<TKey, TValue>();
                    dict.Add(key, group);
                }

                group.Add(item);
            }

            return dict.Values;
        }

        private class Grouping<TKey, TValue> : List<TValue>, IGrouping<TKey, TValue>
        {
            public TKey Key { get; }
        }
    }
}