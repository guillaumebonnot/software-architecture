using System.Collections.Generic;

namespace Helios.Architecture.Pipeline.Plugins
{
    public class Pipeline: IOperation
    {
        // exposes operations for hooking
        public readonly LinkedList<IOperation> Operations = new LinkedList<IOperation>();

        // add operation at the end of the pipeline
        public void Register(IOperation operation)
        {
            Operations.AddLast(operation);
        }

        // invoke every operations
        public void Invoke()
        {
            foreach (var operation in Operations) operation.Invoke();
        }
    }
}
