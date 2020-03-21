using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SynchronizationPrimitives.Primitives
{
    /// <summary>
    /// Явно идентифицирует поток, которому дан монопольный доступ к критической секции
    /// </summary>
    class MutexPrimitive : Primitive
    {
        public static Mutex mutex = new Mutex();

        internal override void Lock()
        {
            bool got = mutex.WaitOne(); // true
            mutex.WaitOne();
        }

        internal override void Unlock()
        {
            mutex.ReleaseMutex(); // Освободить может только владеющий поток
            mutex.ReleaseMutex();
        }
    }
}
