using System;

namespace Helios.Architecture.Pipeline.Plugins
{
    public class Operation : IOperation
    {
        private readonly Action action;

        public Operation(Action action)
        {
            this.action = action;
        }

        public void Invoke() => action();
    }
}