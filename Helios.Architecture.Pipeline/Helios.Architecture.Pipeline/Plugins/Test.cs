namespace Helios.Architecture.Pipeline.Plugins
{
    public static class Test
    {
        public static void Run()
        {
            var application = new Application();
            application.RegisterPlugin(new HookPlugin());
            application.RegisterPlugin(new LatePlugin());
            application.Initialize();
            application.Run();
        }
    }
}