using System;
using System.Threading.Tasks;

namespace Asynchronous.TaskWait
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
                
                var tasks = new Task[3];
                for (var i = 0; i < tasks.Length; i++)
                {
                    tasks[i] = new Task(() => Sum(1000000));
                    tasks[i].Start();
                }

                var task0Exception = tasks[0].Exception;
                
                // var index = Task.WaitAny(tasks);
                // var doneWithinAMinute = Task.WaitAll(tasks, TimeSpan.FromMinutes(1));
                
                // Create a Task (it does not start running now)
                Task<Int32> t = new Task<Int32>(n => Sum((Int32) n), 1000000000);
// You can start the task sometime later
                t.Start();
// Optionally, you can explicitly wait for the task to complete
                t.Wait(); // FYI: Overloads exist accepting timeout/CancellationToken
// You can get the result (the Result property internally calls Wait)
                Console.WriteLine("The Sum is: " + t.Result); // An Int32 value
            }
            catch (AggregateException e)
            {
                var innerException = e.InnerException;
                var innerExceptions = e.InnerExceptions; // element 0 of Aggregate Exception ’s InnerExceptions property would refer to the actual System.Overflow­Exception object thrown by the compute-bound method (Sum) 
                var baseException = e.GetBaseException(); // AggregateException ’s implementation returns the innermost AggregateException that is the root cause of the problem
                // e.Flatten();
                // e.Handle(HandleException);
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }

        private static void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Console.WriteLine($"{e.GetType()} - {e}");
        }

        private static bool HandleException(Exception e)
        {
            return true;
        }

        private static Int32 Sum(int n)
        {
            Int32 sum = 0;
            for (; n > 0; n--)
                checked { sum += n; } // if n is large, this will throw System.OverflowException
            return sum;
        }
    }
}