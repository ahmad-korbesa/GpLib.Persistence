using System.Collections.Generic;

namespace GpLib.Persistence.EventStore
{
    public interface IEventStream
    {
        public string StreamId { get; set; }

        public IEnumerable<IEvent> CommittedEvents { get; set; }
    }
}
