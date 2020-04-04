using System;

namespace Helios.Architecture.Pipeline.CircuitBreaker
{
    public class CheckNotNullOperation<T> : IOperation<T> where T : class
    {
        public bool Invoke(T data)
        {
            if (data == null)
            {
                Console.WriteLine("The data in the pipeline should not be null");
                return false;
            }

            return true;
        }
    }
}