using System;

namespace GpLib.Persistence.EventStore
{
    public interface IEvent
    {
        DateTime Timestamp { get; }

        object Payload { get; set; }

    }
}