using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Threading;

// Set assembly's culture to Swiss German
// [assembly:AssemblyCulture("de­CH")]
[assembly:AssemblyCulture("")]

// FileDescription version information:
// [assembly: AssemblyTitle("MultiFileLibrary.dll")]
// Comments version information:
[assembly: AssemblyDescription("This assembly contains Blocking_Collection's types")]
// CompanyName version information:
// [assembly: AssemblyCompany("BetConstruct")]
// ProductName version information:
// [assembly: AssemblyProduct("BetConstruct (R) MultiFileLibrary's Type Library")]
// LegalCopyright version information:
[assembly: AssemblyCopyright("Copyright (c) BetConstruct 2020")]
// LegalTrademarks version information:
[assembly:AssemblyTrademark("Blocking_Collection is a registered trademark of BetConstruct")]
// AssemblyVersion version information:
// [assembly: AssemblyVersion("3.0.0.0")]
// FILEVERSION/FileVersion version information:
// [assembly: AssemblyFileVersion("1.0.0.0")]
// PRODUCTVERSION/ProductVersion version information:
// [assembly: AssemblyInformationalVersion("2.0.0.0")]

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