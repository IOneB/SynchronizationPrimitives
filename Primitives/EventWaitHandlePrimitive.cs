using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SynchronizationPrimitives.Primitives
{
    class EventWaitHandlePrimitive : Primitive
    {
        readonly EventWaitHandle ewh = new EventWaitHandle(true, EventResetMode.ManualReset); // функциональные аналоги - AutoResetEvent и ManualResetEvent. (Manual пропускает всех добравшихся)

        public EventWaitHandlePrimitive()
        {
        }

        internal override void Lock()
        {
            ewh.WaitOne();
            //ewh.Reset(); Для Manual
        }

        internal override void Unlock()
        {
            ewh.Set();
        }

        internal override void AfterRun()
        {
            //ewh.Set();
        }
    }
}
