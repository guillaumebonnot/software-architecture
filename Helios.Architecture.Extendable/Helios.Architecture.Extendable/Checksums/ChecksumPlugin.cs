using System;

namespace Helios.Architecture.Extendable.Checksums
{
    internal class ChecksumPlugin : IPlugin
    {
        public static readonly Property<Event, int> ChecksumProperty = new Property<Event, int>("Checksum");

        static ChecksumPlugin()
        {
            Event.RegisterProperty(ChecksumProperty);
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
            Console.WriteLine($"{ChecksumProperty.Name} : {@event.GetChecksum()}");
        }
    }
}