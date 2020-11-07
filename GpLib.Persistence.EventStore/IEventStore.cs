using System.Collections.Generic;
using System.Threading.Tasks;

namespace GpLib.Persistence.EventStore
{
    public interface IEventStore
    {
        Task<IEventStream> CreateStream(string streamId);
        
        Task<IEventStream> LoadEventStream(string streamId, int version);

        Task AppendToStream(string streamId, int exptectedVersion, IEnumerable<IEvent> events);
    }
}
