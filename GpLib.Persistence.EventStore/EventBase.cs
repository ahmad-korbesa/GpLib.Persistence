using System;

namespace GpLib.Persistence.EventStore
{
    public class EventBase : IEvent
    {
        public object Payload { get; set; }

        public DateTime Timestamp { get; set; }

    }
}
