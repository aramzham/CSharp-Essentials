using System;
using System.Threading.Tasks;

namespace CoreFacilities.Exceptions.Intro
{
    class Program
    {
        static void Main()
        {
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;

            try
            {
                // uncomment this line if you want to break the application
                // Environment.FailFast("fail this program fast");
                throw new ArgumentException("argument exception");
            }
            catch // in watch window you can see exception by $exception variable
            {
                // ignored
            }
            finally
            {
                Console.WriteLine("this block will always execute");

                // Aborting a thread or unloading an AppDomain causes the CLR to throw a ThreadAbortException , which allows the
                // finally block to execute.If a thread is simply killed via the Win32 TerminateThread function, or if the process is killed
                // via the Win32 TerminateProcess function or System.Environment’s FailFast method, then the finally block will
                // not execute.
            }

            Task.Run(() =>
            {
                try
                {
                    throw new NullReferenceException("null exception");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw; // you will see exception message for 3 times
                }
            });

            Console.WriteLine($"1 + 1 = {1 + 1}");

            Console.ReadKey();
        }

        private static void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            Console.WriteLine(e.Exception);
        }
    }
}
