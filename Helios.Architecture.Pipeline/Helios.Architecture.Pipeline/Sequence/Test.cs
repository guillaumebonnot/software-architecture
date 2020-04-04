using System;

namespace Helios.Architecture.Pipeline.Sequence
{
    public static class Test
    {
        public static void Run()
        {
            // build
            var pipeline = new Pipeline<string>();

            // lambda
            pipeline.Register(new Operation<string>(str =>
            {
                Console.WriteLine($"The string {str} contains {str.Length} characters.");
            }));

            // class
            pipeline.Register(new ReverseOperation());

            // execute
            pipeline.Invoke("apple");
        }
    }
}