using System;
using System.Collections.Generic;
using System.Linq;

namespace Helios.Architecture.Scrambler.Pipelines
{
    public class AsynchronousPipeline
    {
        private readonly List<Step> steps = new List<Step>();

        public abstract class Step
        {
            public int Index;
            public Step NextStep;
            public Action<bool> Terminate;

            public virtual void Execute()
            {
                DoWork();
            }

            protected abstract void DoWork();
            protected abstract string GetName();

            protected virtual void Success()
            {
                if (NextStep != null)
                {
                    NextStep.Execute();
                }
                else
                {
                    Terminate(true);
                }
            }

            protected virtual void Fail(string reason)
            {
                Terminate(false);
            }
        }

        public virtual void Start()
        {
            steps.First().Execute();
        }

        public void SetNextStep(Step step)
        {
            step.Terminate = Terminate;
            if (steps.Any())
            {
                steps.Last().NextStep = step;
            }

            steps.Add(step);
            step.Index = steps.Count;
        }

        protected virtual void Terminate(bool success)
        {
        }
    }
}