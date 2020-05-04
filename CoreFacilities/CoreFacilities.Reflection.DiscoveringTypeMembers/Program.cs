using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoreFacilities.Reflection.DiscoveringTypeMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Loop through all assemblies loaded in this AppDomain
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var a in assemblies)
            {
                Show(0, "Assembly: {0}", a);
                // Find Types in the assembly
                foreach (var t in a.ExportedTypes)
                {
                    Show(1, "Type: {0}", t);
                    // Discover the type's members
                    foreach (var mi in t.GetTypeInfo().DeclaredMembers)
                    {
                        var typeName = string.Empty;
                        switch (mi)
                        {
                            case Type _: typeName = "(Nested) Type"; break;
                            case FieldInfo _: typeName = "FieldInfo"; break;
                            case MethodInfo _: typeName = "MethodInfo"; break;
                            case ConstructorInfo _: typeName = "ConstructorInfo"; break;
                            case PropertyInfo _: typeName = "PropertyInfo"; break;
                            case EventInfo _: typeName = "EventInfo"; break;
                        }

                        Show(2, "{0}: {1}", typeName, mi);
                    }
                }
            }

            Console.ReadKey();
        }

        private static void Show(int indent, string format, params object[] args)
        {
            Console.WriteLine(new string(' ', 3 * indent) + format, args);
        }
    }
}
