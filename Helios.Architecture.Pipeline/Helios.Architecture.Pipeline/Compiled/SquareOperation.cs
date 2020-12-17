using Helios.Architecture.Pipeline.Sequence;

namespace Helios.Architecture.Pipeline.Compiled
{
    class SquareOperation : IOperation<Parameter<int>>
    {
        public void Invoke(Parameter<int> data) => data.Data *= data.Data;
    }
}