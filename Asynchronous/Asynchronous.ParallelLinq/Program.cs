using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Asynchronous.ParallelLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(0, 10000);
            var sw = new Stopwatch();
            sw.Start();
            
            // if you want to preserve the order => use .AsOrdered()
            // var sums = list.Select(GetSum).AsParallel().AsOrdered().ToList();
            var sums = list.AsParallel()
                .WithDegreeOfParallelism(Environment.ProcessorCount)
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .WithMergeOptions(ParallelMergeOptions.FullyBuffered)
                .AsUnordered()
                .Select(GetSum)
                .ToList(); // with parallel i was getting about 470ms instead of 640ms, here we don't have any order at the end
            // sums.ForAll(Console.WriteLine); not a good idea, cause console will use synchronization tools and we won't get any improvement....comment .ToList() from sums
            sw.Stop();
            Console.WriteLine($"passed {sw.ElapsedMilliseconds}ms");

            Console.ReadKey();
        }

        static long GetSum(int i)
        {
            return Enumerable.Range(1, i).Sum();
        }
    }
}