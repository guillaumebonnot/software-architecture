using System;

namespace Helios.Architecture.Pipeline.Asynchronous
{
    public static class Test
    {
        public static void Run()
        {
            // the main pipeline
            var pipeline = new Pipeline<string>();
            pipeline.RegisterOperation(new Operation<string>(data =>
            {
                Console.WriteLine($"Everyone likes {data} !");
                return true;
            }));
            pipeline.RegisterOperation(new WriteOperation());
            pipeline.RegisterOperation(new Operation<string>(data =>
            {
                if (data == "banana")
                {
                    Console.WriteLine("This banana made the pipeline abort...");
                    return false;
                }

                return true;
            }));
            pipeline.RegisterOperation(new Operation<string>(data => Console.WriteLine("This operation should not be called !")));
            
            // a verbose pipeline to wrap the main pipeline
            var verbose = new Pipeline<string>();
            verbose.RegisterOperation(new Operation<string>(data => Console.WriteLine("Beginning of the pipeline...")));
            verbose.RegisterOperation(pipeline);
            verbose.RegisterOperation(new Operation<string>(data => Console.WriteLine("End of the pipeline...")));
            verbose.Invoke("banana");

            Console.WriteLine("The pipeline is asynchronous, so we should have more messages after this one : ");
        }
    }
}