using System;
using System.Threading;

namespace Threads_02_Optimization
{
    class Program
    {
        private static bool stopWorker = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Main: letting worker run for 1 seconds");

            var t = new Thread(Worker);
            t.Start();
            Thread.Sleep(500);
            stopWorker = true;
            Console.WriteLine("Main: waiting for worker to stop");
            Console.ReadLine();
        }

        private static void Worker(object state)
        {
            var x = 0;

            while (!stopWorker)
            {
                x++;
            }

            Console.WriteLine($"Worker: stopped at: {x}");
        }

        private static void OptimizedAway()
        {
            int value = (1 * 100) - (50 * 2);

            for (int i = 0; i < value; i++)
            {
                Console.WriteLine("Opmtimized away");
            }
        }
    }
}
