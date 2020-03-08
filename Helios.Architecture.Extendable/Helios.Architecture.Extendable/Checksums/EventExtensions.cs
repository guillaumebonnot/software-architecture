namespace Helios.Architecture.Extendable.Checksums
{
    public static class EventExtensions
    {
        public static readonly Property<Event, int> ChecksumProperty = new Property<Event, int>("Checksum");

        public static int GetChecksum(this Event @event)
        {
            return ChecksumProperty.Get(@event);
        }

        public static void SetChecksum(this Event @event, int checksum)
        {
            ChecksumProperty.Set(@event, checksum);
        }
    }
}