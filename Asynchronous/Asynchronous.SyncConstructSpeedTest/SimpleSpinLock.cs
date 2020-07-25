using System;
using System.Threading;

namespace Asynchronous.SyncConstructSpeedTest
{
    internal struct SimpleSpinLock {
        private Int32 m_ResourceInUse; // 0=false (default), 1=true
        public void Enter() {
            while (true) {
// Always set resource to in­use
// When this thread changes it from not in­use, return
                if (Interlocked.Exchange(ref m_ResourceInUse, 1) == 0) return;
// Black magic goes here...
            }
        }
        public void Leave() {
// Set resource to not in­use
            Volatile.Write(ref m_ResourceInUse, 0);
        }
    }
}