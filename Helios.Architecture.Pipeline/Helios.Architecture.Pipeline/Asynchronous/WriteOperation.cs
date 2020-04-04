using System;
using System.Threading;
using System.Threading.Tasks;

namespace Helios.Architecture.Pipeline.Asynchronous
{
    public class WriteOperation : IOperation<string>
    {
        private IOperation<string> next;

        public void SetNext(IOperation<string> next)
        {
            this.next = next;
        }

        public void Invoke(string data)
        {
            Task.Run(() =>
            {
                Console.WriteLine("Writing data to the disk...");
                Thread.Sleep(100); // just kidding !
                Console.WriteLine("Data successfully written to the disk !");
                next?.Invoke(data);
            });
        }
    }
}