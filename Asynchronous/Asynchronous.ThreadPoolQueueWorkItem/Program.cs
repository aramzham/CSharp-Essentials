using System;
using System.Threading;

namespace Asynchronous.ThreadPoolQueueWorkItem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread: queuing an asynchronous operation");
            ThreadPool.QueueUserWorkItem(ComputeBoundOp, 5);
            ThreadPool.QueueUserWorkItem(AnyOtherMethodMatchingThisSignature);
            Console.WriteLine("Main thread: Doing other work here...");
            Thread.Sleep(10000); // Simulating other work (10 seconds)
            Console.WriteLine("Hit <Enter> to end this program...");
            Console.ReadLine();
        }

        private static void ComputeBoundOp(object state)
        {
            // This method is executed by a thread pool thread
            Console.WriteLine("In ComputeBoundOp: state={0}", state);
            Thread.Sleep(1000); // Simulates other work (1 second)
            // When this method returns, the thread goes back
            // to the pool and waits for another task
        }

        private static void AnyOtherMethodMatchingThisSignature(object obj)
        {
            Console.WriteLine("any object can be added to thread pool queue as far as it matches WaitCallback delegate signature");
        }
    }
}