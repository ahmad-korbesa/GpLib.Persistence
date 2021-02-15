using System.Collections.Generic;

namespace GpLib.Persistence.EventStore
{
    public interface IEventStream
    {
        string StreamId { get; set; }

        IEnumerable<IEvent> CommittedEvents { get; set; }
    }
}
