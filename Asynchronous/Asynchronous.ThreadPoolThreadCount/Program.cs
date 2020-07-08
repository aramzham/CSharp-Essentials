using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchronous.ThreadPoolThreadCount
{
    class Program
    {
        static void Main(string[] args)
        {
            // it's highly discouraged to use these methods
            // GetMaxThreads , SetMaxThreads , GetMinТhreads , SetMinThreads , and GetAvailableThreads
            ThreadPool.SetMinThreads(0, 0); // min is (4, 4) for my machine
            ThreadPool.SetMaxThreads(13, 5);
            ThreadPool.GetMaxThreads(out var workerThreads, out var completionPortThreads);
            Console.WriteLine($"Max thread count = {workerThreads}, completion port threads = {completionPortThreads}");
            ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads); // min threads count = processors count
            Console.WriteLine($"Min thread count = {workerThreads}, completion port threads = {completionPortThreads}");
            for (int i = 0; i < 100; i++)
            {
                Task.Run(Work);
            }

            ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine($"There are {workerThreads} worker threads");
            Console.WriteLine($"There are {completionPortThreads} completion port threads");

            Console.ReadKey();
        }

        static void Work()
        {
            Console.WriteLine($"Working in thread {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);
        }
    }
}