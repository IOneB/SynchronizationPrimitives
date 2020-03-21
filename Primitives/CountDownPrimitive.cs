using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SynchronizationPrimitives.Primitives
{
    class CountDownPrimitive : Primitive
    {
        CountdownEvent cde = new CountdownEvent(2);

        internal override void Lock()
        {
            cde.Wait(); //Ожидать
        }

        internal override void Unlock()
        {
            cde.Reset(2); //Установить
        }

        internal override void AfterRun()
        {
            cde.Signal(); //Отнять
            cde.AddCount(); //Можно добавить
            cde.Signal();
            cde.Signal();
        }
    }
}
