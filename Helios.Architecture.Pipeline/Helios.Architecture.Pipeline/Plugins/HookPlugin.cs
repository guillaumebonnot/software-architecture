using System;

namespace Helios.Architecture.Pipeline.Plugins
{
    class HookPlugin : Application.Plugin
    {
        public override void Initialize(Application application)
        {
            var operations = application.Pipeline.Operations;
            operations.AddAfter(operations.First, new Operation(() => Console.WriteLine("I really want to be second !")));
        }
    }
}
