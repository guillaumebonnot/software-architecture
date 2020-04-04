namespace Helios.Architecture.Pipeline.Batch
{
    public static class Test
    {
        public static void Run()
        {
            // base pipeline
            var pipeline = new Pipeline<int>();
            pipeline.Register(new CheckMagnitudeOperation(1));
            pipeline.Register(new CheckMagnitudeOperation(2));
            pipeline.Register(new CheckMagnitudeOperation(3));
            pipeline.Register(new CheckMagnitudeOperation(4));
            
            // batch pipeline
            var batch = new BatchPipeline<int>(pipeline);
            batch.Invoke(new []{ 12, 345, 6789 });
        }
    }
}