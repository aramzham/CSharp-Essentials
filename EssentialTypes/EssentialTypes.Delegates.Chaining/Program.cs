using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialTypes.Delegates.Chaining
{
    // ATTENTION!!! this is a pseudocode

    //internal class MyDelegateType : MulticastDelegate
    //{
    //    private object _target;
    //    private IntPtr _methodPtr;
    //    private MyDelegateType[] _invocationList;

    //    public MyDelegateType(object obj, IntPtr methodPtr)
    //    {
    //        _target = obj;
    //        _methodPtr = methodPtr;
    //    }

    //    public virtual int Invoke(string value) // signature of Invoke depends on the defined delegate signature
    //    {
    //        var result = default(int);

    //        if(_invocationList != null)
    //        {
    //            foreach (var d in _invocationList)
    //            {
    //                d(value);
    //            }
    //        }
    //        else
    //        {
    //            result = _methodPtr.Invoke(_target, value);
    //        }

    //        return result;
    //    }

    //    // Methods allowing the callback to be called asynchronously, deprecated
    //    public virtual IAsyncResult BeginInvoke(Int32 value, AsyncCallback callback, Object @object);
    //    public virtual void EndInvoke(IAsyncResult result);
    //}

    public delegate void Feedback(int value);

    class Program
    {
        static void Main(string[] args)
        {
            ChainingDemo();
        }

        private static void Counter(int from, int to, Feedback fb)
        {
            for (int val = from; val <= to; val++)
            {
                // If any callbacks are specified, call them
                fb?.Invoke(val);
            }
        }

        private static void ChainingDemo()
        {
            var fbChain = default(Feedback);
            var fb1 = new Feedback(Program.WriteToConsole);
            fbChain = (Feedback)Delegate.Combine(fbChain, fb1);
            Console.WriteLine($"References are equal = {object.ReferenceEquals(fbChain, fb1)}");
            Counter(1, 3, fbChain);
        }

        private static void WriteToConsole(int value)
        {
            Console.WriteLine(value);
        }
    }
}
