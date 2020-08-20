using Helios.Architecture.Scrambler.Analysis.Operations;
using Helios.Architecture.Scrambler.Pipelines;

namespace Helios.Architecture.Scrambler.Analysis
{
    class ScramblerAlgorithm
    {
        private readonly VerbosePipeline pipeline = new VerbosePipeline();
        private readonly VerbosePipeline encode = new VerbosePipeline();
        private readonly VerbosePipeline decode = new VerbosePipeline();

        public ScramblerAlgorithm()
        {
            // main pipeline
            var seed = new Parameter<TrackerArray>("seed");

            pipeline.SetNextStep(new InitializeOperation(seed));
            pipeline.SetNextStep(new PipelineOperation(nameof(encode), encode));
            pipeline.SetNextStep(new PipelineOperation(nameof(decode), decode));

            // encode pipeline
            var shift1 = new Parameter<TrackerArray>("shift1");
            var shift2 = new Parameter<TrackerArray>("shift2");
            var xor1 = new Parameter<TrackerArray>("xor1");
            var encoded = new Parameter<TrackerArray>("encoded");
            
            encode.SetNextStep(new ShiftRightOperation(seed, shift1, 13));
            encode.SetNextStep(new XorOperation(seed, shift1, xor1));
            encode.SetNextStep(new ShiftLeftOperation(xor1, shift2, 18));
            encode.SetNextStep(new XorOperation(xor1, shift2, encoded));

            // decode pipeline
            var deshift1 = new Parameter<TrackerArray>("deshift1");
            var deshift2 = new Parameter<TrackerArray>("deshift2");
            var deshift3 = new Parameter<TrackerArray>("deshift3");
            var dexor1 = new Parameter<TrackerArray>("dexor1");
            var dexor2 = new Parameter<TrackerArray>("dexor2");
            var decoded = new Parameter<TrackerArray>("decoded");
            
            decode.SetNextStep(new ShiftLeftOperation(encoded, deshift1, 18));
            decode.SetNextStep(new XorOperation(encoded, deshift1, dexor1));
            decode.SetNextStep(new ShiftRightOperation(dexor1, deshift2, 13));
            decode.SetNextStep(new XorOperation(dexor1, deshift2, dexor2));
            decode.SetNextStep(new ShiftRightOperation(dexor2, deshift3, 26));
            decode.SetNextStep(new XorOperation(dexor2, deshift3, decoded));
        }

        public void Analyze()
        {
            pipeline.Start();
        }
    }
}