namespace Helios.Architecture.Extendable.Signatures
{
    public static class EventExtensions
    {
        public static byte[] GetSignature(this Event @event)
        {
            return SignaturePlugin.SignatureProperty.Get(@event);
        }

        public static void SetSignature(this Event @event, byte[] signature)
        {
            SignaturePlugin.SignatureProperty.Set(@event, signature);
        }
    }
}