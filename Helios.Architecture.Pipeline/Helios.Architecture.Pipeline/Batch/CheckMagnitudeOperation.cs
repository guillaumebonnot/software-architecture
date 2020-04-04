using System;

namespace Helios.Architecture.Pipeline.Batch
{
    public class CheckMagnitudeOperation : IOperation<int>
    {
        private readonly int threshold;

        public CheckMagnitudeOperation(int magnitude)
        {
            threshold = (int) Math.Pow(10, magnitude);
        }

        public bool Invoke(int data)
        {
            if (data < threshold)
            {
                Console.WriteLine($"{data} < {threshold} -> ko");
                return false;
            }

            Console.WriteLine($"{data} >= {threshold} -> ok");
            return true;
        }
    }
}