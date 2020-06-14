using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchronous.ContinueWith
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TaskStatus

            var currentStatus = default(Task)?.Status;
            Console.WriteLine(currentStatus);
            var t1 = new Task(() => SleepTaskForSeconds(5), TaskCreationOptions.PreferFairness);
            Console.WriteLine(t1.Status);
            t1.Start();
            Console.WriteLine(t1.Status);
            Thread.Sleep(1000);
            Console.WriteLine(t1.Status);
            Thread.Sleep(4000);
            Console.WriteLine(t1.Status);

            #endregion
            
            #region child tasks

            // TaskCreationOptions.AttachedToParent flag associates a Task with the Task that creates it so
            // that the creating task is not considered finished until all its children (and grandchildren) have finished
            // running
            var parent = new Task<double[]>(() =>
            {
                var results = new double[3]; // Create an array for the results
// This tasks creates and starts 3 child tasks
                new Task(() => results[0] = RunTaskUntilSeconds(1, CancellationToken.None),
                    TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = RunTaskUntilSeconds(2, CancellationToken.None),
                    TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = RunTaskUntilSeconds(3, CancellationToken.None),
                    TaskCreationOptions.AttachedToParent).Start();
// Returns a reference to the array (even though the elements may not be initialized yet)
                return results;
            });

            // When the parent and its children have run to completion, display the results
            var cwt = parent.ContinueWith(parentTask => Array.ForEach(parentTask.Result, Console.WriteLine));
// Start the parent Task so it can start its children
            parent.Start();

            Console.WriteLine($"parent task id = {parent.Id}");
            Console.WriteLine($"Current task id = {Task.CurrentId}");
            Console.WriteLine($"Task status = {parent.Status}");
            Console.WriteLine($"Task exception = {parent.Exception}");
            Console.WriteLine(
                $"Task reference to the object that is to be passed to the callback method = {parent.AsyncState}");
            //System.InvalidOperationException: A task may only be disposed if it is in a completion state (RanToCompletion, Faulted or Canceled)
            parent.Dispose(); // all the Dispose method does is close the ManualResetEventSlim object,  just let the garbage collector clean up

            #endregion

            #region continue with

            var cts = new CancellationTokenSource();
            // Create and start a Task, continue with multiple other task
            var t = Task.Run(() => RunTaskUntilSeconds(5, cts.Token), cts.Token);
            cts.Cancel();

            try
            {
// If the task got canceled, Result will throw an AggregateException
                Console.WriteLine("RunTaskUntilSeconds worked for : " + t.Result + "s"); // An Int32 value
            }
            catch (AggregateException x)
            {
// Consider any OperationCanceledException objects as handled.
// Any other exceptions cause a new AggregateException containing
// only the unhandled exceptions to be thrown
                x.Handle(e => e is OperationCanceledException);
// If all the exceptions were handled, the following executes
                Console.WriteLine("Our task was canceled");
            }

            // Each ContinueWith returns a Task but you usually don't care
            t.ContinueWith(task => Console.WriteLine("RunTaskUntilSeconds worked for : " + task.Result + "s"),
                TaskContinuationOptions.OnlyOnRanToCompletion);
            t.ContinueWith(
                task => Console.WriteLine("RunTaskUntilSeconds threw: " +
                                          (task.Exception?.InnerException ?? (object) "no exception")),
                TaskContinuationOptions.OnlyOnFaulted);
            t.ContinueWith(task => Console.WriteLine("RunTaskUntilSeconds was canceled"),
                TaskContinuationOptions.OnlyOnCanceled);

            #endregion

            Console.ReadKey();
        }

        private static double RunTaskUntilSeconds(int i, CancellationToken ctsToken)
        {
            //throw new Exception("throw, my little child");
            ctsToken.ThrowIfCancellationRequested();
            var r = new Random();
            var next = r.NextDouble() * i;
            Thread.Sleep(TimeSpan.FromSeconds(next));
            return next;
        }

        private static void SleepTaskForSeconds(int i)
        {
            var r = new Random();
            var next = r.NextDouble() * i;
            Thread.Sleep(TimeSpan.FromSeconds(next));
        }
    }
}