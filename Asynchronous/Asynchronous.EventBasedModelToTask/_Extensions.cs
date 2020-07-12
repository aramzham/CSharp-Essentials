using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Asynchronous.EventBasedModelToTask
{
    public static class _Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] // Causes compiler to optimize the call away
        public static void NoWarning(this Task _){ /* no code here*/}
    }
}