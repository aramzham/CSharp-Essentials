namespace Asynchronous.ThreadSafeSingleton
{
    public class ClassicSingleton
    {
        private static ClassicSingleton _singleton = new ClassicSingleton();
        
        // Private constructor prevents any code outside this class from creating an instance
        private ClassicSingleton()
        {
            // Code to initialize the one Singleton object goes here...
        }

        // Public, static method that returns the Singleton object (creating it if necessary)
        public static ClassicSingleton GetInstance => _singleton;
    }
}