using System;
using System.Collections.Generic;

namespace Helios.Architecture.Pipeline.Plugins
{
    class Application
    {
        internal abstract class Plugin
        {
            public abstract void Initialize(Application application);
        }

        private readonly List<Plugin> plugins = new List<Plugin>();
        public readonly Pipeline Pipeline = new Pipeline();

        public void RegisterPlugin(Plugin plugin)
        {
            plugins.Add(plugin);
        }

        public void Initialize()
        {
            Pipeline.Register(new Operation(() => Console.WriteLine("Step 1")));
            Pipeline.Register(new Operation(() => Console.WriteLine("Step 2")));
            Pipeline.Register(new Operation(() => Console.WriteLine("Step 3")));

            foreach (var plugin in plugins) plugin.Initialize(this);
        }

        public void Run()
        {
            Pipeline.Invoke();
        }
    }
}