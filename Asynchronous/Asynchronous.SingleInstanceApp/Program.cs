using System;
using System.Threading;

namespace Asynchronous.SingleInstanceApp
{
    // Try running two instances of the same application ;) 
    class Program
    {
        static void Main(string[] args)
        {
            // Try to create a kernel object with the specified name
            using (new Semaphore(0, 1, "SomeUniqueStringIdentifyingMyApp", out var createdNew)) {
                if (createdNew) {
// This thread created the kernel object so no other instance of this
// application must be running. Run the rest of the application here...
                    Console.WriteLine("Running the single instance!");
                    Console.ReadKey();
                } else {
// This thread opened an existing kernel object with the same string name;
// another instance of this application must be running now.
// There is nothing to do in here, let's just return from Main to terminate
// this second instance of the application.
                    Console.WriteLine("Another instance must be running now :/");
                    Console.ReadKey();
                }
            }
        }
    }
}