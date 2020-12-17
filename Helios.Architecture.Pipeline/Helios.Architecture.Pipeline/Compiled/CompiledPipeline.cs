using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Helios.Architecture.Pipeline.Sequence;

namespace Helios.Architecture.Pipeline.Compiled
{
    public class CompiledPipeline<T> : IOperation<T>
    {
        private readonly List<IOperation<T>> operations = new List<IOperation<T>>();
        private Action<T> compiled;

        public CompiledPipeline()
        {
            compiled = CompileAndInvoke;
        }

        // add operation at the end of the pipeline
        public void Register(IOperation<T> operation)
        {
            operations.Add(operation);
        }

        // invoke every operations
        public void Invoke(T data)
        {
            compiled(data);
        }

        public void Compile()
        {
            var data = Expression.Parameter(typeof(T), "data");
            var method = typeof(IOperation<T>).GetMethod(nameof(IOperation<T>.Invoke));
            // foreach (var operation in operations) operation.Invoke(data);
            var body = Expression.Block(operations.Select(operation => Expression.Call(Expression.Constant(operation), method, data)));
            compiled = Expression.Lambda<Action<T>>(body, data).Compile();
        }

        public void CompileAndInvoke(T data)
        {
            Compile();
            Invoke(data);
        }
    }
}