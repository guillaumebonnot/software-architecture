using System;

namespace Helios.Architecture.Pipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            Sequence.Test.Run();
            Console.ReadLine();
            Asynchronous.Test.Run();
            Console.ReadLine();
            Plugins.Test.Run();
            Console.ReadLine();
            Batch.Test.Run();
            Console.ReadLine();
            Processors.Test.Run();
            Console.ReadLine();
            Console.WriteLine("Finished !");
            Console.ReadLine();
        }
    }
}
