using System.Collections.Generic;
using System.Linq;

namespace Helios.Architecture.Pipeline.Asynchronous
{
    class Pipeline<T> : IOperation<T>
    {
        // not the best
        private readonly List<IOperation<T>> operations = new List<IOperation<T>>();
        private readonly IOperation<T> terminate;

        public Pipeline()
        {
            terminate = new Operation<T>(data => {}); // not the best
        }

        void IOperation<T>.SetNext(IOperation<T> next)
        {
            terminate.SetNext(next);
        }

        // append an operation at the end of the pipeline
        public void RegisterOperation(IOperation<T> operation)
        {
            // when the operation is finished, it will call terminate
            operation.SetNext(terminate);
            if (operations.Any())
            {
                // link the last registered operation with the newly registered one
                operations.Last().SetNext(operation);
            }
            operations.Add(operation);
        }

        public void Invoke(T data)
        {
            var operation = operations.Any() ? operations.First() : terminate;
            operation.Invoke(data);
        }
    }
}
