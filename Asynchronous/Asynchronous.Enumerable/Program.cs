using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asynchronous.Enumerable
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var asyncList = FetchDataStream();
            await foreach (var item in asyncList)
            {
                Console.WriteLine(item);
            }

            var taskList = FetchData();
            foreach (var item in await taskList)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        private static async Task<IEnumerable<int>> FetchData()
        {
            var list = new List<int>(10);
            for (int i = 1; i < 11; i++)
            {
                await Task.Delay(500);
                list.Add(i);
            }

            return list;
        }

        static async IAsyncEnumerable<int> FetchDataStream()
        {
            for (int i = 1; i < 11; i++)
            {
                await Task.Delay(500);
                yield return i;
            }
        }
    }
}
