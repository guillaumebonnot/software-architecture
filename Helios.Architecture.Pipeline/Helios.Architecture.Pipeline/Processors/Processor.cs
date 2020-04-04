using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Helios.Architecture.Pipeline.Processors
{
    abstract class Processor<T> : IOperation<T>
    {
        private readonly BlockingCollection<T> queue = new BlockingCollection<T>();

        public IOperation<T> Next { private get; set; }
        public IOperation<T> Terminate { private get; set; }
        void IOperation<T>.Invoke(T data) => queue.Add(data);

        protected Processor()
        {
            Task.Run(Run);
        }

        private void Run()
        {
            Console.WriteLine($"Thread {GetType().Name} Started !");
            while (true)
            {
                var data = queue.Take();
                var operation = Process(data) ? Next : Terminate;
                operation.Invoke(data);
                Sleep(); // hack to have random output ;)
            }
        }

        private static readonly Random random = new Random();
        private static void Sleep()
        {
            var x = random.Next(10);
            Thread.Sleep(x*x); 
        }

        protected abstract bool Process(T data);
    }
}
