using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronizationPrimitives
{
    abstract class Primitive
    {
        protected virtual void InnerDo(int value, ref int total)
        {
            Lock();
            // critical section
            Console.Write("Thread id - " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(", Value - " + value);
            total += value;
            Thread.Sleep(1000);
            Unlock();
            ThreadDone();
        }

        internal virtual void ThreadDone()
        {
        }

        internal abstract void Unlock();
        internal abstract void Lock();

        public virtual void Do()
        {
            List<Thread> threads = new List<Thread>();
            int total = 0;

            for (int i = 0; i < 10; i++)
            {
                int x = i;
                Thread t = new Thread(() => InnerDo(x, ref total));
                threads.Add(t);
                t.Start();
            }
            AfterRun();
            threads.ForEach(t => t.Join());
            Console.WriteLine($"\nКонец! Вывод - {total}");
        }

        internal virtual void AfterRun()
        {

        }
    }
}
