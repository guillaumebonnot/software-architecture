using System;
using System.Collections.Generic;

namespace Helios.Architecture.Pipeline.CircuitBreaker
{
    class Pipeline<T> : IOperation<T>
    {
        private readonly List<IOperation<T>> operations = new List<IOperation<T>>();

        // add operation at the end of the pipeline
        public void Register(IOperation<T> operation)
        {
            operations.Add(operation);
        }

        // invoke every operations
        public bool Invoke(T data)
        {
            foreach (var operation in operations)
            {
                if (!operation.Invoke(data))
                {
                    Console.WriteLine("Aborting pipeline..");
                    return false;
                }
            }

            return true;
        }
    }
}
