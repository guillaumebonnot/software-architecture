using System.Collections.Generic;

namespace Helios.Architecture.Pipeline.Sequence
{
    public class Pipeline<T> : IOperation<T>
    {
        private readonly List<IOperation<T>> operations = new List<IOperation<T>>();

        // add operation at the end of the pipeline
        public void Register(IOperation<T> operation)
        {
            operations.Add(operation);
        }

        // invoke every operations
        public void Invoke(T data)
        {
            foreach (var operation in operations) operation.Invoke(data);
        }
    }
}
