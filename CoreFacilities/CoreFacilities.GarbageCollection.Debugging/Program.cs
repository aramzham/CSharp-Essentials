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
        // GC triggers:
        // 1. Code explicitly calls System.GC ’s static Collect method
        // 2. Windows is reporting low memory conditions
        // 3. The CLR is unloading an AppDomain => GC clears everything
        // 4. The CLR is shutting down => GC does nothing, Windows will clear itself

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
