using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EssentialTypes.Delegates.WrappingLocalVariable
{
    // behind the scenes compiler generates a helper class to work with local variables
    internal sealed class BehindScenesAClass 
    {
        public static void UsingLocalVariablesInTheCallbackCode(int numToDo) 
        {
            WaitCallback callback1 = null;

            var class1 = new DisplayClass2();
            class1.numToDo = numToDo;
            class1.squares = new int[class1.numToDo];
            class1.done = new AutoResetEvent(false);

            for (int n = 0; n < class1.squares.Length; n++)
            {
                if (callback1 is null) 
                {
                    callback1 = new WaitCallback(class1.UsingLocalVariablesInTheCode_b__0);
                }

                ThreadPool.QueueUserWorkItem(callback1, n);
            }

            class1.done.WaitOne();

            for (int n = 0; n < class1.squares.Length; n++)
            {
                Console.WriteLine($"Index {n}, Square={class1.squares[n]}");
            }
        }

        // The helper class is given a strange name <>c__DisplayClass2 to avoid potential
        // conflicts and is private to forbid access from outside AClass
        private sealed class DisplayClass2 : object
        {
            // One public field per local variable used in the callback code
            public int[] squares;
            public int numToDo;
            public AutoResetEvent done;

            public DisplayClass2() { }

            // Public instance method containing the callback code
            public void UsingLocalVariablesInTheCode_b__0(object obj) 
            {
                var num = (int)obj;
                squares[num] = num * num;
                if (Interlocked.Decrement(ref numToDo) == 0)
                    done.Set();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AClass.UsingLocalVariablesInTheCallbackCode(10);
        }
    }

    internal sealed class AClass
    {
        public static void UsingLocalVariablesInTheCallbackCode(int numToDo)
        {
            var squares = new int[numToDo];
            var done = new AutoResetEvent(false);

            for (int n = 0; n < squares.Length; n++)
            {
                ThreadPool.QueueUserWorkItem(x =>
                {
                    var num = (int)x;
                    squares[num] = num * num;
                    if (Interlocked.Decrement(ref numToDo) == 0)
                        done.Set();
                }, n);
            }

            done.WaitOne();

            for (int n = 0; n < squares.Length; n++)
            {
                Console.WriteLine($"Index {n}, Square={squares[n]}");
            }
        }
    }
}
