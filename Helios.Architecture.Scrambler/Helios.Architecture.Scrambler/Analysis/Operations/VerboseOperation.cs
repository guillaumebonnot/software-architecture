using System;
using System.Linq;
using Helios.Architecture.Scrambler.Pipelines;

namespace Helios.Architecture.Scrambler.Analysis.Operations
{
    public abstract class VerboseOperation : VerbosePipeline.Step
    {
        protected readonly Parameter<TrackerArray> output;

        protected VerboseOperation(Parameter<TrackerArray> output)
        {
            this.output = output;
        }

        protected abstract TrackerArray Invoke();

        protected override void DoWork()
        {
            output.Data = Invoke();
            Success();
        }

        protected sealed override void Success()
        {
            Describe(output);
            base.Success();
        }

        private static void Describe(TrackerArray array)
        {
            var layers = array.GetValues().Max(tracker => tracker.GetValues().Count());

            for (int layer = 0; layer < layers; layer++)
            {
                for (int i = 0; i < 32; i++)
                {
                    var values = array.GetValues().ToArray()[i].GetValues().ToArray();
                    var text = layer < values.Length ? Convert.ToString(values[layer]).PadRight(2) : "";
                    Console.Write(text.PadRight(3));
                }
                Console.WriteLine();
            }
        }
    }
}