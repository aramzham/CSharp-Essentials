using System;

namespace Hash_table
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance = new HashTable<int, string>(5);

            instance.Add(0, "Hello");
            instance.Add(1, "World");
            instance.Add(2, "Again");
            instance.Add(3, "!");
            instance.Add(4, "To increase the array lenght");

            foreach (var item in instance)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
