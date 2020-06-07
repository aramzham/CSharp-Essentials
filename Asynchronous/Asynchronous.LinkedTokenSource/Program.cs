using System;
using System.Threading;
using System.Threading.Channels;

namespace Asynchronous.LinkedTokenSource
{
    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            // it seems like cts has a queue of actions that it cancels
            cts.Token.Register(() => Console.WriteLine("Canceled 1"));
            cts.Token.Register(() => Console.WriteLine("Canceled 2"));
            cts.Token.Register(() => Console.WriteLine("Canceled 3"));
            
            cts.Cancel();

            Console.ReadKey();
            
            // Create a CancellationTokenSource
            var cts1 = new CancellationTokenSource();
            cts1.Token.Register(() => Console.WriteLine("cts1 canceled"));
            
            // Create another CancellationTokenSource
            var cts2 = new CancellationTokenSource();
            cts2.Token.Register(() => Console.WriteLine("cts2 canceled"));
            
            // Create a new CancellationTokenSource that is canceled when cts1 or ct2 is canceled
            var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cts1.Token, cts2.Token);
            linkedCts.Token.Register(() => Console.WriteLine("linkedCts canceled...means that one of tokens is cancelled or linkedCts himself is cancelled"));

            // Cancel one of the CancellationTokenSource objects (I chose cts2)
            cts2.Cancel();
            
            // Display which CancellationTokenSource objects are canceled
            Console.WriteLine("cts1 canceled={0}, cts2 canceled={1}, linkedCts canceled={2}",
                cts1.IsCancellationRequested, cts2.IsCancellationRequested,
                linkedCts.IsCancellationRequested);
            
            var cts3 = new CancellationTokenSource(/*TimeSpan.FromSeconds(2)*/);
            cts3.CancelAfter(2000);
            cts3.Token.Register(()=>Console.WriteLine("cts3 is cancelled after 2 seconds"));
            cts.Cancel();
            
            Console.ReadKey();
        }
    }
}