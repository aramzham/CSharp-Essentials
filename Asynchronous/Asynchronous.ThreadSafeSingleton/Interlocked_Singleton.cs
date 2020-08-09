using System.Threading;

namespace Asynchronous.ThreadSafeSingleton
{
    internal sealed class Interlocked_Singleton
    {
        private static Interlocked_Singleton s_value = null;

        // Private constructor prevents any code outside this class from creating an instance
        private Interlocked_Singleton()
        {
            // Code to initialize the one Singleton object goes here...
        }

        // Public, static method that returns the Singleton object (creating it if necessary)
        public static Interlocked_Singleton GetSingleton()
        {
            if (s_value != null) return s_value;

            // Create a new Singleton and root it if another thread didn't do it first
            var temp = new Interlocked_Singleton();
            Interlocked.CompareExchange(ref s_value, temp, null);
            // If this thread lost, then the second Singleton object gets GC'd
            return s_value; // Return reference to the single object
        }
    }
}