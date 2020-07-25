using System;
using System.Threading;

namespace Asynchronous.SyncConstructSpeedTest
{
    internal sealed class SimpleWaitLock : IDisposable {
        private readonly AutoResetEvent m_available;
        public SimpleWaitLock() {
            m_available = new AutoResetEvent(true); // Initially free
        }
        public void Enter() {
// Block in kernel until resource available
            m_available.WaitOne();
        }
        public void Leave() {
// Let another thread access the resource
            m_available.Set();
        }
        public void Dispose() { m_available.Dispose(); }
    }
}