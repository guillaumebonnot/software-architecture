using System;
using System.Diagnostics;

namespace Helios.Architecture.Pipeline.Compiled
{
    public static class Benchmark
    {
        private const int MAX_ITERATIONS = 100000000;

        public static void Run()
        {
            Console.WriteLine("Benchmarking Pipeline...");

            Run("Not Compiled", Test.GetNotCompiledBenchmark);
            Run("Compiled", Test.GetCompiledBenchmark);
        }

        public static void Run(string name, Func<Action> initialize)
        {
            var watch = new Stopwatch();
            watch.Start();

            var action = initialize();
            for (int i = 0; i < MAX_ITERATIONS; i++) action();

            watch.Stop();
            var elapsed = watch.ElapsedMilliseconds;
            Console.WriteLine($"{name} -> Elapsed Time {elapsed} ms");
        }
    }
}