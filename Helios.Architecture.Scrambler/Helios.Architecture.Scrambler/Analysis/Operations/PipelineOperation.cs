using Helios.Architecture.Scrambler.Pipelines;

namespace Helios.Architecture.Scrambler.Analysis.Operations
{
    class PipelineOperation : VerbosePipeline.Step
    {
        private readonly string name;
        private readonly VerbosePipeline pipeline;

        public PipelineOperation(string name, VerbosePipeline pipeline)
        {
            this.name = name;
            this.pipeline = pipeline;
        }

        protected override void DoWork()
        {
            pipeline.Start();
            Success();
        }

        protected override string GetName() => $"starting pipeline {name}";
    }
}
