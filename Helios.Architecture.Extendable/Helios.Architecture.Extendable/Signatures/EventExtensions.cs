namespace Helios.Architecture.Extendable.Signatures
{
    public static class EventExtensions
    {
        public static readonly Property<Event, byte[]> SignatureProperty = new Property<Event, byte[]>("Signature");

        public static byte[] GetSignature(this Event @event)
        {
            return SignatureProperty.Get(@event);
        }

        public static void SetSignature(this Event @event, byte[] signature)
        {
            SignatureProperty.Set(@event, signature);
        }
    }
}