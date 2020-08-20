namespace Helios.Architecture.Scrambler.Analysis.Operations
{
    public class XorOperation : VerboseOperation
    {
        private readonly Parameter<TrackerArray> input1;
        private readonly Parameter<TrackerArray> input2;

        public XorOperation(Parameter<TrackerArray> input1, Parameter<TrackerArray> input2, Parameter<TrackerArray> output) : base(output)
        {
            this.input1 = input1;
            this.input2 = input2;
        }

        protected override string GetName() => $"{output.Name} = {input1.Name} ^ {input2.Name}";

        protected override TrackerArray Invoke()
        {
            return TrackerArray.XOR(input1, input2);
        }
    }
}