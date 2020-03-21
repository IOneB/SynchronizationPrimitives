using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SynchronizationPrimitives.Primitives
{
    /// <summary>
    /// Монитор на минималках (без сборки мусора) - желательно иметь маленькую критическую секцию (потоки бешено бьются в экстазе/цикле)
    /// </summary>
    class SpinLockPrimitive : Primitive
    {
        SpinLock sl = new SpinLock();
        internal override void Lock()
        {
            bool gotLock = false;
            sl.Enter(ref gotLock);

            if (gotLock == false)
                throw new ArgumentException();
        }

        internal override void Unlock()
        {
            sl.Exit();
        }
    }
}
