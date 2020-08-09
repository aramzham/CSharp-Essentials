using System;
using System.Threading;

namespace Asynchronous.ThreadSafeSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a lazy­initialization wrapper around getting the DateTime
            var s = new Lazy<string>(() => DateTime.Now.ToLongTimeString(), true);
            Console.WriteLine(s.IsValueCreated); // Returns false because Value not queried yet
            Console.WriteLine(s.Value); // The delegate is invoked now
            Console.WriteLine(s.IsValueCreated); // Returns true because Value was queried
            Thread.Sleep(10000); // Wait 10 seconds and display the time again
            Console.WriteLine(s.Value); // The delegate is NOT invoked now; same result
            
            string name = null;
            // Because name is null, the delegate runs and initializes name
            LazyInitializer.EnsureInitialized(ref name, () => "Jeffrey");
            Console.WriteLine(name); // Displays "Jeffrey"
            // Because name is not null, the delegate does not run; name doesn't change
            LazyInitializer.EnsureInitialized(ref name, () => "Richter");
            Console.WriteLine(name); // Also displays "Jeffrey"
        }
    }
}