using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;

namespace CoreFacilities.Reflection.InvokingTypeMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(SomeType);
            BindToMemberThenInvokeTheMember(t);
            Console.WriteLine();
            BindToMemberCreateDelegateToMemberThenInvokeTheMember(t);
            Console.WriteLine();
            UseDynamicToBindAndInvokeTheMember(t);
            Console.WriteLine();

            Console.ReadKey();
        }

        // Callback method added to the event
        private static void EventCallback(object sender, EventArgs e) { }

        private static void BindToMemberThenInvokeTheMember(Type t)
        {
            Console.WriteLine("BindToMemberThenInvokeTheMember");
            // Construct an instance
            Type ctorArgument = Type.GetType("System.Int32&"); // or typeof(Int32).MakeByRefType();
            ConstructorInfo ctor = t.GetTypeInfo().DeclaredConstructors.First(
                c => c.GetParameters()[0].ParameterType == ctorArgument);
            object[] args = new object[] { 12 }; // Constructor arguments
            Console.WriteLine("x before constructor called: " + args[0]);
            object obj = ctor.Invoke(args);
            Console.WriteLine("Type: " + obj.GetType());
            Console.WriteLine("x after constructor returns: " + args[0]);
            // Read and write to a field
            FieldInfo fi = obj.GetType().GetTypeInfo().GetDeclaredField("m_someField");
            fi.SetValue(obj, 33);
            Console.WriteLine("someField: " + fi.GetValue(obj));
            // Call a method
            MethodInfo mi = obj.GetType().GetTypeInfo().GetDeclaredMethod("ToString");
            string s = (string)mi.Invoke(obj, null);
            Console.WriteLine("ToString: " + s);
            // Read and write a property
            PropertyInfo pi = obj.GetType().GetTypeInfo().GetDeclaredProperty("SomeProp");
            try
            {
                pi.SetValue(obj, 0, null);
            }
            catch (TargetInvocationException e)
            {
                if (e.InnerException.GetType() != typeof(ArgumentOutOfRangeException)) throw; Console.WriteLine("Property set catch.");
            }
            pi.SetValue(obj, 2, null);
            Console.WriteLine("SomeProp: " + pi.GetValue(obj, null));
            // Add and remove a delegate from the event
            EventInfo ei = obj.GetType().GetTypeInfo().GetDeclaredEvent("SomeEvent");
            EventHandler eh = new EventHandler(EventCallback); // See ei.EventHandlerType
            ei.AddEventHandler(obj, eh);
            ei.RemoveEventHandler(obj, eh);
        }

        private static void BindToMemberCreateDelegateToMemberThenInvokeTheMember(Type t)
        {
            Console.WriteLine("BindToMemberCreateDelegateToMemberThenInvokeTheMember");
            // Construct an instance (You can't create a delegate to a constructor)
            object[] args = new object[] { 12 }; // Constructor arguments
            Console.WriteLine("x before constructor called: " + args[0]);
            object obj = Activator.CreateInstance(t, args);
            Console.WriteLine("Type: " + obj.GetType().ToString());
            Console.WriteLine("x after constructor returns: " + args[0]);
            // NOTE: You can't create a delegate to a field
            // Call a method
            MethodInfo mi = obj.GetType().GetTypeInfo().GetDeclaredMethod("ToString");
            var toString = mi.CreateDelegate<Func<string>>(obj);
            string s = toString();
            Console.WriteLine("ToString: " + s);
            // Read and write a property
            PropertyInfo pi = obj.GetType().GetTypeInfo().GetDeclaredProperty("SomeProp");
            var setSomeProp = pi.SetMethod.CreateDelegate<Action<int>>(obj);
            try
            {
                setSomeProp(0);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Property set catch.");
            }
            setSomeProp(2);
            var getSomeProp = pi.GetMethod.CreateDelegate<Func<int>>(obj);
            Console.WriteLine("SomeProp: " + getSomeProp());
            // Add and remove a delegate from the event
            EventInfo ei = obj.GetType().GetTypeInfo().GetDeclaredEvent("SomeEvent");
            var addSomeEvent = ei.AddMethod.CreateDelegate<Action<EventHandler>>(obj);
            addSomeEvent(EventCallback);
            var removeSomeEvent = ei.RemoveMethod.CreateDelegate<Action<EventHandler>>(obj);
            removeSomeEvent(EventCallback);
        }

        private static void UseDynamicToBindAndInvokeTheMember(Type t)
        {
            Console.WriteLine("UseDynamicToBindAndInvokeTheMember");
            // Construct an instance (You can't use dynamic to call a constructor)
            object[] args = new object[] { 12 }; // Constructor arguments
            Console.WriteLine("x before constructor called: " + args[0]);
            dynamic obj = Activator.CreateInstance(t, args);
            Console.WriteLine("Type: " + obj.GetType().ToString());
            Console.WriteLine("x after constructor returns: " + args[0]);
            // Read and write to a field
            try
            {
                obj.m_someField = 5;
                int v = (int)obj.m_someField;
                Console.WriteLine("someField: " + v);
            }
            catch (RuntimeBinderException e)
            {
                // We get here because the field is private
                Console.WriteLine("Failed to access field: " + e.Message);
            }
            // Call a method
            string s = (string)obj.ToString();
            Console.WriteLine("ToString: " + s);
            // Read and write a property
            try
            {
                obj.SomeProp = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Property set catch.");
            }
            obj.SomeProp = 2;
            int val = (int)obj.SomeProp;
            Console.WriteLine("SomeProp: " + val);
            // Add and remove a delegate from the event
            obj.SomeEvent += new EventHandler(EventCallback);
            obj.SomeEvent -= new EventHandler(EventCallback);
        }
    }

    internal sealed class SomeType
    {
        private int m_someField;
        public SomeType(ref int x) { x *= 2; }
        public override string ToString() { return m_someField.ToString(); }

        public int SomeProp
        {
            get { return m_someField; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("value");
                m_someField = value;
            }
        }

        public event EventHandler SomeEvent;
        private void NoCompilerWarnings() { SomeEvent.ToString(); }
    }

    internal static class ReflectionExtensions
    {
        // Helper extension method to simplify syntax to create a delegate
        public static TDelegate CreateDelegate<TDelegate>(this MethodInfo mi, object target = null)
        {
            return (TDelegate)(object)mi.CreateDelegate(typeof(TDelegate), target);
        }
    }
}
