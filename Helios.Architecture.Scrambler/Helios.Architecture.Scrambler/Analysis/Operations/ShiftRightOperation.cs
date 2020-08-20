namespace Helios.Architecture.Scrambler.Analysis.Operations
{
    public class ShiftRightOperation : VerboseOperation
    {
        private readonly Parameter<TrackerArray> input;
        private readonly int offset;

        public ShiftRightOperation(Parameter<TrackerArray> input, Parameter<TrackerArray> output, int offset) : base(output)
        {
            this.offset = offset;
            this.input = input;
        }

        protected override string GetName() => $"{output.Name} = {input.Name} >> {offset}";

        protected override TrackerArray Invoke()
        {
            return input.Data.ShiftRight(offset);
        }
    }
}