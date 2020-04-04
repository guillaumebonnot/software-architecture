using System.Collections.Generic;
using System.Linq;

namespace Helios.Architecture.Pipeline.Processors
{
    class Pipeline<T> : IOperation<T>
    {
        private readonly List<IOperation<T>> operations = new List<IOperation<T>>();

        public IOperation<T> Next { private get; set; }
        public IOperation<T> Terminate { private get; set; }

        private readonly IOperation<T> success;
        private readonly IOperation<T> fail;

        public Pipeline()
        {
            success = new Operation<T>(Success);
            fail = new Operation<T>(Fail);
        }
        
        // append an operation at the end of the pipeline
        public void RegisterOperation(IOperation<T> operation)
        {
            // when the operation is finished, it will call either call success or fail
            operation.Next = success;
            operation.Terminate = fail;

            if (operations.Any())
            {
                // link the last registered operation with the newly registered one
                operations.Last().Next = operation;
            }
            operations.Add(operation);
        }

        public void Invoke(T data)
        {
            var operation = operations.Any() ? operations.First() : fail;
            operation.Invoke(data);
        }

        private bool Success(T data)
        {
            Continue(data);
            return true;
        }

        private bool Fail(T data)
        {
            // we decide to bypass the circuit breaker
            Continue(data);
            return false;
        }

        private void Continue(T data)
        {
            Next?.Invoke(data);
        }
    }
}