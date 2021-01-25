using System.Collections.Generic;

namespace _04_yield
{
    public static class Extensions
    {
        public static IEnumerable<int> EvenNumbers(this IEnumerable<int> enumerable)
        {
            // return enumerable.Where(item => item % 2 == 0);
            foreach (var item in enumerable)
                if (item % 2 == 0)
                    yield return item;
        }

        public static IEnumerable<int> GreaterThan(this IEnumerable<int> enumerable, int value)
        {
            // return enumerable.Where(item => item > value);
            foreach (var item in enumerable)
                if (item > value)
                    yield return item;
        }
    }
}