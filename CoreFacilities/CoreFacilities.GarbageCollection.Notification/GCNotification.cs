using System;
using System.Threading;

namespace CoreFacilities.GarbageCollection.Notification
{
    public static class GCNotification
    {
        private static Action<int> s_gcDone = null; // The event's field
        public static event Action<int> GCDone
        {
            add
            {
                // If there were no registered delegates before, start reporting notifications now
                if (s_gcDone == null) { new GenObject(0); new GenObject(2); }
                s_gcDone += value;
            }
            remove { s_gcDone -= value;}
        }
        private sealed class GenObject
        {
            private int m_generation;
            public GenObject(int generation) { m_generation = generation; }
            ~GenObject()
            { // This is the Finalize method
                // If this object is in the generation we want (or higher),
                // notify the delegates that a GC just completed
                if (GC.GetGeneration(this) >= m_generation)
                {
                    var temp = Volatile.Read(ref s_gcDone);
                    temp?.Invoke(m_generation);
                }
                // Keep reporting notifications if there is at least one delegate registered,
                // the AppDomain isn't unloading, and the process isn’t shutting down
                if ((s_gcDone != null)
                    && !AppDomain.CurrentDomain.IsFinalizingForUnload()
                    && !Environment.HasShutdownStarted)
                {
                    // For Gen 0, create a new object; for Gen 2, resurrect the object
                    // & let the GC call Finalize again the next time Gen 2 is GC'd
                    if (m_generation == 0) new GenObject(0);
                    else GC.ReRegisterForFinalize(this);
                }
                else { /* Let the objects go away */ }
            }
        }
    }
}