using System;
using System.Collections.Generic;

namespace Helios.Architecture.Extendable
{
    public interface IPlugin
    {
        void OnCreateEvent(Event @event);
        void OnDisplayEvent(Event @event);
    }

    internal class Application
    {
        private readonly List<IPlugin> plugins = new List<IPlugin>();

        public void RegisterPlugin(IPlugin plugin)
        {
            plugins.Add(plugin);
        }

        public Event CreateEvent(string name)
        {
            var @event = new Event {Name = name};
            plugins.ForEach(plugin => plugin.OnCreateEvent(@event));
            return @event;
        }

        public void DisplayEvent(Event @event)
        {
            Console.WriteLine("Event Received !");
            Console.WriteLine($"{nameof(Event.Name)} : {@event.Name}");
            plugins.ForEach(plugin => plugin.OnDisplayEvent(@event));
        }
    }
}