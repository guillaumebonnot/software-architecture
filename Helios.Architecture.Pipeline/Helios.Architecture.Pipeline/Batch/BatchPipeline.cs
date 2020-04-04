using System;
using System.Linq;

namespace Helios.Architecture.Pipeline.Batch
{
    class BatchPipeline<T> : IOperation<T[]>
    {
        private readonly Pipeline<T> pipeline;

        public BatchPipeline(Pipeline<T> pipeline)
        {
            this.pipeline = pipeline;
        }

        // invoke each operation on each item
        public bool Invoke(T[] data)
        {
            // wrap items
            var items = data.Select(item => new Result<T>(item)).ToArray();

            foreach (var operation in pipeline.Operations)
            {
                // detects when every operation failed
                var failed = true;

                foreach (var item in items)
                {
                    if(!item.Success) continue;
                    if (!operation.Invoke(item.Data)) item.Fail();
                    else failed = false;
                }

                // circuit breaker
                if (failed) return false;
                Console.WriteLine("----------------------");
            }

            return true;
        }
    }
}