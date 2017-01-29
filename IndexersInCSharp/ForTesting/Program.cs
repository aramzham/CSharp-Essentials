using System;
using System.Diagnostics;
using TellMeDayOfTheWeek;
using StellarSystem;
using StellarSystem = StellarSystem.StellarSystem;

namespace ForTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw1 = Stopwatch.StartNew();
            var tell1 = new DayOfTheWeekManager();
            var d1 = "Wednesday";
            var a1 = default(int);
            var iteration = 1000000;
            for (int i = 0; i < iteration; i++)
            {
                a1 = tell1[d1];
            }
            Console.WriteLine($"DayOfTheWeekManager on {iteration} iterations used {sw1.ElapsedMilliseconds} milliseconds");

            Console.WriteLine(new string('-', 50));

            var secondTimer = Stopwatch.StartNew();
            var tell2 = new CustomWeekDayManager();
            var a2 = default(int);
            for (int i = 0; i < iteration; i++)
            {
                a2 = tell2[d1];
            }
            Console.WriteLine($"CustomWeekDayManager on {iteration} iterations used {secondTimer.ElapsedMilliseconds} milliseconds");

            Console.WriteLine("\n" + new string('_', 50));

            var system = new SolarSystem(); // sounds funny, right? :-)
            Console.WriteLine($"The 9th planet of Solar system is {system[9]}");
            Console.WriteLine($"Pluto is Solar system's {system["Pluto"]}th planet");

            Console.ReadKey();
        }
    }
}
