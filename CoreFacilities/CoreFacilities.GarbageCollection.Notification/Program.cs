using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreFacilities.GarbageCollection.Notification
{
    class Program
    {
        private static int _count = 0;
        static void Main(string[] args)
        {
            GCNotification.GCDone += GCNotificationOnGCDone;
            GC.RegisterForFullGCNotification(1, 20);
            GC.WaitForFullGCApproach(2000);
            GC.WaitForFullGCComplete(4000);

            var s = "";
            for (; _count < 100000; _count++)
            {
                s += _count.ToString();
                Thread.Sleep(5);
                // you'll see how gc adapts generation 0 budget
            }

            Console.ReadKey();
        }

        private static void GCNotificationOnGCDone(int obj)
        {
            Console.Beep();
            Console.WriteLine($"GC collection started in generation {obj}, _count = {_count}");
        }
    }
}
