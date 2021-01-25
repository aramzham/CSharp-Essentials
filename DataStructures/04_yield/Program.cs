using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _04_yield;

public class Program
{
    static async Task Main()
    {
        // if you try to get into function with F11, you won't succeed
        var en = CreateRandomNumbers(100);

        var filtered = en.EvenNumbers().GreaterThan(50);

        // all the filtration will take place here
        var list = filtered.ToList();

        Console.ReadKey();
    }

    static IEnumerable<int> CreateRandomNumbers(int count)
    {
        var rnd = new Random();
        for (int i = 0; i < count; i++)
            yield return rnd.Next(0, 150);
    }
}