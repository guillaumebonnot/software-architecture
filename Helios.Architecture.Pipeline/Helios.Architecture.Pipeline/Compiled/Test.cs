using System;
using Helios.Architecture.Pipeline.Sequence;

namespace Helios.Architecture.Pipeline.Compiled
{
    public static class Test
    {
        public static Action GetNotCompiledBenchmark()
        {
            // build
            var pipeline = new Pipeline<Parameter<int>>();

            // lambda
            pipeline.Register(new Operation<Parameter<int>>(data => data.Data += data.Data));

            // class
            pipeline.Register(new SquareOperation());

            // execute
            return () => pipeline.Invoke(new Parameter<int>(500));
        }

        public static Action GetCompiledBenchmark()
        {
            // build
            var pipeline = new CompiledPipeline<Parameter<int>>();

            // lambda
            pipeline.Register(new Operation<Parameter<int>>(data => data.Data += data.Data));

            // class
            pipeline.Register(new SquareOperation());

            // execute
            return () => pipeline.Invoke(new Parameter<int>(500));
        }
    }
}
