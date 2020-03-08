using System;
using Helios.Architecture.Extendable.Signatures;

namespace Helios.Architecture.Extendable
{
    class Program
    {
        static void Main(string[] args)
        {
            // setup application
            var app = new Application();
            app.RegisterPlugin(CreatePlugin());

            // create an event
            var @event = app.CreateEvent("subscription");
            // display the event
            app.DisplayEvent(@event);

            Console.ReadKey();
        }

        private static IPlugin CreatePlugin()
        {
            // return new ChecksumPlugin();
            return new SignaturePlugin();
        }
    }
}
