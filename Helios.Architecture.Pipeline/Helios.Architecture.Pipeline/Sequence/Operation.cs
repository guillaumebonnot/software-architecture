using System;

namespace Helios.Architecture.Pipeline.Sequence
{
    public class Operation<T> : IOperation<T>
    {
        private readonly Action<T> action;
        
        public Operation(Action<T> action)
        {
            this.action = action;
        }

        public void Invoke(T data) => action(data);
    }
}