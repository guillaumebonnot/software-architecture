using System;

namespace Helios.Architecture.Extendable.Checksums
{
    internal class ChecksumPlugin : IPlugin
    {
        static ChecksumPlugin()
        {
            Event.RegisterProperty(EventExtensions.ChecksumProperty);
        }

        public void OnCreateEvent(Event @event)
        {
            @event.SetChecksum(ComputeChecksum(@event));
        }

        private int ComputeChecksum(Event @event)
        {
            return @event.Name.GetHashCode();
        }

        public void OnDisplayEvent(Event @event)
        {
            Console.WriteLine($"{EventExtensions.ChecksumProperty.Name} : {@event.GetChecksum()}");
        }
    }
}