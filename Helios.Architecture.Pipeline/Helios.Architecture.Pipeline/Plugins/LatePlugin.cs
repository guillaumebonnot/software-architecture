using System;

namespace Helios.Architecture.Pipeline.Plugins
{
    class LatePlugin : Application.Plugin
    {
        public override void Initialize(Application application)
        {
            application.Pipeline.Register(new Operation(() => Console.WriteLine("Sorry guys, I am late...")));
        }
    }
}