using System;
using System.IO.Pipes;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// before first await keyword all the work is done by main thread, compiler sees the await, gives the work to another thread and frees the main until the worker thread finishes its job
namespace Asynchronous.AsyncFunctionsInit
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine($"Thread number in Main = {Thread.CurrentThread.ManagedThreadId}");
                var result = IssueClientRequestAsync("https://mic.am/").GetAwaiter().GetResult();
                Console.WriteLine($"Thread number in Main after IssueClientRequestAsync = {Thread.CurrentThread.ManagedThreadId}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }

        private static async Task<string> IssueClientRequestAsync(string serverName)
        {
            Console.WriteLine($"Thread number in IssueClientRequestAsync = {Thread.CurrentThread.ManagedThreadId}");
            using (var client = new HttpClient())
            {
                Console.WriteLine($"Thread number before client.GetStringAsync = {Thread.CurrentThread.ManagedThreadId}");
                var task = client.GetStringAsync(serverName);
                Console.WriteLine($"Thread number after creating task = {Thread.CurrentThread.ManagedThreadId}");
                var result = await task;
                Console.WriteLine($"Thread number before getting resultq = {Thread.CurrentThread.ManagedThreadId}");
                var resultq = await client.GetStringAsync(serverName);
                Console.WriteLine($"Thread number after resultq = {Thread.CurrentThread.ManagedThreadId}");
                var resultq2 = await client.GetStringAsync(serverName);
                Console.WriteLine($"Thread number after resultq2 = {Thread.CurrentThread.ManagedThreadId}");
                return result;
            }
        }
    }
}