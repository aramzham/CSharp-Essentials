using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreFacilities.GarbageCollection.Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            // When you compile your assembly by using the C# compiler’s /debug switch, the compiler applies a
            // System.Diagnostics.DebuggableAttribute with its DebuggingModes' DisableOptimizations flag set into the resulting assembly.
            // At run time, when compiling a method, the JIT compiler sees this
            // flag set, and artificially extends the lifetime of all roots to the end of the method.
            var t = new Timer(TCallback, null, 0, 2000);

            Console.ReadKey();
        }

        private static void TCallback(object state)
        {
            Console.WriteLine($"In TCallback: {DateTime.Now}");

            // Force garbage collection
            GC.Collect();
        }
    }
}
