namespace Helios.Architecture.Extendable.Checksums
{
    public static class EventExtensions
    {
        public static int GetChecksum(this Event @event)
        {
            return ChecksumPlugin.ChecksumProperty.Get(@event);
        }

        public static void SetChecksum(this Event @event, int checksum)
        {
            ChecksumPlugin.ChecksumProperty.Set(@event, checksum);
        }
    }
}