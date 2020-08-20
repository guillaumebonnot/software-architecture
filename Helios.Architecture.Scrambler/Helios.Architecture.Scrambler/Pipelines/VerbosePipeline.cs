using System;

namespace Helios.Architecture.Scrambler.Pipelines
{
    public class VerbosePipeline : AsynchronousPipeline
    {
        public new abstract class Step : AsynchronousPipeline.Step
        {
            public override void Execute()
            {
                Console.WriteLine();
                Console.WriteLine($"Executing Step {Index} : {GetName()}");
                base.Execute();
            }

            protected override void Fail(string reason)
            {
                Console.WriteLine($"Failed at Step {Index} : {GetName()} -> {reason}");
                base.Fail(reason);
            }
        }

        public override void Start()
        {
            Console.WriteLine();
            Console.WriteLine("Start of the pipeline");
            base.Start();
        }

        protected override void Terminate(bool success)
        {
            Console.WriteLine();
            var result = success ? "Success" : "Failure";
            Console.WriteLine($"End of the pipeline : {result}");
            base.Terminate(success);
        }
    }
}
