using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Asynchronous.Blocking_Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            var bl = new BlockingCollection<int>(new ConcurrentQueue<int>());
            // A thread pool thread will do the consuming
            ThreadPool.QueueUserWorkItem(ConsumeItems, bl);
            // Add 5 items to the collection, if you don't add anything is this collection then threadpool thread will block on .GetConsumingEnumerable()
            for (var item = 0; item < 5; item++)
            {
                Console.WriteLine("Producing: " + item);
                bl.Add(item);
            }

            // Tell the consuming thread(s) that no more items will be added to the collection
            bl.CompleteAdding();
            Console.WriteLine("Finished the program");
            Console.ReadLine(); // For testing purposes
        }

        private static void ConsumeItems(object o)
        {
            var bl = (BlockingCollection<int>) o;
            // Block until an item shows up, then process it
            foreach (var item in bl.GetConsumingEnumerable())
            {
                Console.WriteLine("Consuming: " + item);
            }

            // The collection is empty and no more items are going into it
            Console.WriteLine("All items have been consumed");
        }
    }
}