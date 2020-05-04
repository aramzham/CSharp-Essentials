using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoreFacilities.Reflection.RuntimeHandles
{
    class Program
    {
        private const BindingFlags c_bf = BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

        static void Main(string[] args)
        {
            // Show size of heap before doing any reflection stuff
            Show("Before doing anything");
            // Build cache of MethodInfo objects for all methods in MSCorlib.dll
            var methodInfos = new List<MethodBase>();
            foreach (var t in typeof(object).Assembly.GetExportedTypes())
            {
                // Skip over any generic types
                if (t.IsGenericTypeDefinition) continue;
                MethodBase[] mb = t.GetMethods(c_bf);
                methodInfos.AddRange(mb);
            }
            // Show number of methods and size of heap after binding to all methods
            Console.WriteLine("# of methods={0:N0}", methodInfos.Count);
            Show("After building cache of MethodInfo objects");

            // Build cache of RuntimeMethodHandles for all MethodInfo objects
            var methodHandles = methodInfos.ConvertAll<RuntimeMethodHandle>(mb => mb.MethodHandle);
            Show("Holding MethodInfo and RuntimeMethodHandle cache");
            GC.KeepAlive(methodInfos); // Prevent cache from being GC'd early
            methodInfos = null; // Allow cache to be GC'd now
            Show("After freeing MethodInfo objects");
            methodInfos = methodHandles.ConvertAll<MethodBase>(MethodBase.GetMethodFromHandle);
            Show("Size of heap after re­creating MethodInfo objects");
            GC.KeepAlive(methodHandles); // Prevent cache from being GC'd early
            GC.KeepAlive(methodInfos); // Prevent cache from being GC'd early
            methodHandles = null; // Allow cache to be GC'd now
            methodInfos = null; // Allow cache to be GC'd now
            Show("After freeing MethodInfos and RuntimeMethodHandles");

            Console.ReadKey();
        }

        private static void Show(string title)
        {
            Console.WriteLine($"Heap size =\t{GC.GetTotalMemory(true)} bytes - {title}");
        }
    }
}
