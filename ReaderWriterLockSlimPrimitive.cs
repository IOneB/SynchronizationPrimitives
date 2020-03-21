using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SynchronizationPrimitives
{
    /// <summary>
    /// Один пишет, все читают. Но перед чтением ждут записи, если такое есть!
    /// Не очень подходит для данной задачи
    /// Скорее для реализации конкурентных чтение/запись
    /// </summary>
    class ReaderWriterLockSlimPrimitive : Primitive
    {
        ReaderWriterLockSlim @lock = new ReaderWriterLockSlim();
        bool free = false;
        object o = new object();

        internal override void Lock()
        {
            lock (o)
            {
                if (!free)
                {
                    @lock.EnterWriteLock();
                    free = true;
                }
                else
                    @lock.EnterReadLock();
            }
        }

        internal override void Unlock()
        {
            if (@lock.IsWriteLockHeld)
                @lock.ExitWriteLock(); // Как только write завершится - ломанутся все риды, что были в очереди
            else
                @lock.ExitReadLock();
        }
    }
}
