using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SynchronizationPrimitives.Primitives
{

    /// <summary>
    /// Применять для параллельных вычислений для n потоков.
    /// Поток ждет прибытия всех остальных для приступания к следующей фазе
    /// Не подходит для данной задачи
    /// </summary>
    class BarrierPrimitive : Primitive
    {
        readonly Barrier b = new Barrier(9, b => Console.WriteLine($"Post action phase {b.CurrentPhaseNumber} count {b.ParticipantCount}"));

        public BarrierPrimitive()
        {
            b.AddParticipants(2);
            b.RemoveParticipant();
        }

        internal override void Lock()
        {
            b.SignalAndWait();
        }

        internal override void Unlock()
        {
            b.SignalAndWait();
            b.RemoveParticipant(); // В последней фазе поток удаляет себя из задач
        }

        internal override void ThreadDone()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " done");
        }
    }
}
