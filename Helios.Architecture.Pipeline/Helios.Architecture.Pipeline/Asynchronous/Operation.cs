using System;

namespace Helios.Architecture.Pipeline.Asynchronous
{
    class Operation<T> : IOperation<T>
    {
        private readonly Func<T, bool> action;
        private IOperation<T> next;

        public Operation(Func<T, bool> action)
        {
            this.action = action;
        }

        public Operation(Action<T> action)
        {
            this.action = data =>
            {
                action(data);
                return true;
            };
        }

        public void SetNext(IOperation<T> next)
        {
            this.next = next;
        }

        public void Invoke(T data)
        {
            if (action(data)) next.Invoke(data);
        }
    }
}