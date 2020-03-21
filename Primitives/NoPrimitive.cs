using System;
using System.Collections.Generic;
using System.Text;

namespace SynchronizationPrimitives.Primitives
{
    class NoPrimitive : Primitive
    {
        internal override void Lock()
        {
        }

        internal override void Unlock()
        {
        }
    }
}
