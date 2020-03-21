using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SynchronizationPrimitives.Primitives
{
    class AutoResetEventPrimitive : Primitive
    {
        AutoResetEvent resetEvent = new AutoResetEvent(true);

        internal override void Lock()
        {
        }

        internal override void Unlock()
        {
        }
    }
}
