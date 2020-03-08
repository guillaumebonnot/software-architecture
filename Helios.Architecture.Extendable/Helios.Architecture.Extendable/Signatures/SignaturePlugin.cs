using System;

namespace Helios.Architecture.Extendable.Signatures
{
    internal class SignaturePlugin : IPlugin
    {
        static SignaturePlugin()
        {
            Event.RegisterProperty(EventExtensions.SignatureProperty);
        }

        public void OnCreateEvent(Event @event)
        {
            @event.SetSignature(ComputeSignature(@event));
        }

        private byte[] ComputeSignature(Event @event)
        {
            return Convert.FromBase64String("aSBhbSB0aGUgYmVzdA==");
        }

        public void OnDisplayEvent(Event @event)
        {
            Console.WriteLine($"{EventExtensions.SignatureProperty.Name} : {Convert.ToBase64String(@event.GetSignature())}");
        }
    }
}