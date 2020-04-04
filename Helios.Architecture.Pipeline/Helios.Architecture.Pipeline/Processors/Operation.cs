using System;

namespace Helios.Architecture.Pipeline.Processors
{
    class Operation<T> : IOperation<T>
    {
        private readonly Func<T, bool> action;

        public Operation(Func<T, bool> action)
        {
            this.action = action;
        }

        public IOperation<T> Next { private get; set; }
        public IOperation<T> Terminate { private get; set; }

        public void Invoke(T data)
        {
            var operation = action(data) ? Next : Terminate;
            operation?.Invoke(data);
        }
    }
}