using System;

namespace Helios.Architecture.Extendable.Signatures
{
    internal class SignaturePlugin : IPlugin
    {
        public static readonly Property<Event, byte[]> SignatureProperty = new Property<Event, byte[]>("Signature");

        static SignaturePlugin()
        {
            Event.RegisterProperty(SignatureProperty);
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
            Console.WriteLine($"{SignatureProperty.Name} : {Convert.ToBase64String(@event.GetSignature())}");
        }
    }
}