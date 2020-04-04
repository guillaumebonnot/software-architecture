using System;
using System.Linq;

namespace Helios.Architecture.Pipeline.Sequence
{
    public class ReverseOperation : IOperation<string>
    {
        public void Invoke(string data) => Console.WriteLine($"The string is reversed : {new string(data.Reverse().ToArray())}");
    }
}