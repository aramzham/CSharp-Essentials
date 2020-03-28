using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

[assembly: CLSCompliant(true)]
namespace EssentialTypes.CustomAttributes.Use
{
    [Serializable]
    [DefaultMemberAttribute("Main")]
    [DebuggerDisplayAttribute("Richter", Name = "Jeff", Target = typeof(Program))]
    class Program
    {
        [Conditional("Debug")]
        [Conditional("Release")]
        public void DoSomething() { }
        public Program()
        {
            // when a compiler detects a custom attribute applied to a target, the compiler constructs
            // an instance of the attribute class by calling its constructor, passing it any specified parameters

            // the best way for developers to think of custom attributes:
            // instances of classes that have been serialized to a byte stream that resides in metadata.
            // Later, at run time, an instance of the class can be constructed by deserializing the bytes
            // contained in the metadata.In reality, what actually happens is that the compiler emits
            // the information necessary to create an instance of the attribute class into metadata
        }

        [CLSCompliant(true)]
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Program has {0}FlagsAttribute", typeof(Program).IsDefined(typeof(FlagsAttribute), false) ? string.Empty : "not ");

            // Show the set of attributes applied to this type
            ShowAttributes(typeof(Program));

            // Get the set of methods associated with the type
            var members = from m in typeof(Program).GetTypeInfo().DeclaredMembers.OfType<MethodBase>()
                          where m.IsPublic
                          select m;
            foreach (MemberInfo member in members)
            {
                // Show the set of attributes applied to this member
                ShowAttributes(member);
            }
        }

        private static void ShowAttributes(MemberInfo attributeTarget)
        {
            var attributes = attributeTarget.GetCustomAttributes<Attribute>();
            Console.WriteLine("Attributes applied to {0}: {1}",
            attributeTarget.Name, (!attributes.Any() ? "None" : string.Empty));
            foreach (Attribute attribute in attributes)
            {
                // Display the type of each applied attribute
                Console.WriteLine(" {0}", attribute.GetType().ToString());
                if (attribute is DefaultMemberAttribute)
                    Console.WriteLine(" MemberName={0}", ((DefaultMemberAttribute)attribute).MemberName);
                if (attribute is ConditionalAttribute)
                    Console.WriteLine(" ConditionString={0}", ((ConditionalAttribute)attribute).ConditionString);
                if (attribute is CLSCompliantAttribute)
                    Console.WriteLine(" IsCompliant={0}", ((CLSCompliantAttribute)attribute).IsCompliant);
                var dda = attribute as DebuggerDisplayAttribute;
                if (dda != null)
                {
                    Console.WriteLine(" Value={0}, Name={1}, Target={2}", dda.Value, dda.Name, dda.Target);
                }
            }
            Console.WriteLine();
        }
    }
}
