using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SynchronizationPrimitives.Primitives
{
    /// <summary>
    /// Несколько потоков
    /// Межпроцессорный. Для одного приложения лучше semaphoreSlim
    /// </summary>
    class SemaphorePrimitive : Primitive
    {
        public Semaphore semaphore = new Semaphore(2, 2, "MySem");

        internal override void Lock()
        {
            semaphore.WaitOne();
        }

        internal override void Unlock()
        {
            semaphore.Release();
        }
    }
}
