using System.Threading;

namespace SynchronizationPrimitives
{
    class MonitorPrimitive : Primitive
    {
        public static object o = new object();

        internal override void Lock()
        {
            Monitor.Enter(o);
        }

        internal override void Unlock()
        {
            Monitor.Exit(o);
        }
    }
}
