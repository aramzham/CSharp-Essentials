using System;
using System.Threading;

namespace Asynchronous.ThreadSafeSingleton
{
    internal sealed class Thread_Safe_Singleton
    {
        // s_lock is required for thread safety and having this object assumes that creating
        // the singleton object is more expensive than creating a System.Object object and that
        // creating the singleton object may not be necessary at all. Otherwise, it is more
        // efficient and easier to just create the singleton object in a class constructor
        private static readonly object s_lock = new object();

        // This field will refer to the one Singleton object
        private static Thread_Safe_Singleton s_value = null;

        // Private constructor prevents any code outside this class from creating an instance
        private Thread_Safe_Singleton()
        {
            // Code to initialize the one Singleton object goes here...
        }

        // Public, static method that returns the Singleton object (creating it if necessary)
        public static Thread_Safe_Singleton GetSingleton()
        {
            // If the Singleton was already created, just return it (this is fast)
            if (s_value != null) 
                return s_value;
            
            Monitor.Enter(s_lock); // Not created, let 1 thread create it
            if (s_value is null)
            {
                // Still not created, create it
                var temp = new Thread_Safe_Singleton();
                // Save the reference in s_value (see discussion for details)
                Volatile.Write(ref s_value, temp);
            }

            Monitor.Exit(s_lock);
            // Return a reference to the one Singleton object
            return s_value;
        }
    }
}