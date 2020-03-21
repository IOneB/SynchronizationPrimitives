using System.Threading;

namespace SynchronizationPrimitives.Primitives
{
    internal class SpinWaitPrimitive : Primitive
    {
        SpinWait sw;
        int j = 1;

        internal override void Lock()
        {
            sw = new SpinWait();
            for (int i = 0; i < 1000 * j; i++)
            {
                sw.SpinOnce(); //выполняет холостой цикл. Продолжительность ожидания зависит от скорости процессора.
            }
            j++; //Костыль шоппц
        }

        internal override void Unlock()
        {
        }
    }
}