namespace Helios.Architecture.Scrambler.Analysis.Operations
{
    public class InitializeOperation : VerboseOperation
    {
        public InitializeOperation(Parameter<TrackerArray> output) : base(output) { }

        protected override string GetName() => $"initialize {output.Name}";

        protected override TrackerArray Invoke()
        {
            return TrackerArray.New();
        }
    }
}