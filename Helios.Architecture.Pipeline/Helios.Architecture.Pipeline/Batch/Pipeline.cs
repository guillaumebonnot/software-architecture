using System.Collections.Generic;

namespace Helios.Architecture.Pipeline.Batch
{
    class Pipeline<T> : IOperation<T>
    {
        internal readonly List<IOperation<T>> Operations = new List<IOperation<T>>();

        // add operation at the end of the pipeline
        public void Register(IOperation<T> operation)
        {
            Operations.Add(operation);
        }

        // invoke every operations
        public bool Invoke(T data)
        {
            foreach (var operation in Operations)
            {
                if (!operation.Invoke(data))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
