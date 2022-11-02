using DomainDrivenDesignExample.Domain.Aggregates;
using DomainDrivenDesignExample.Domain.Events;
using IIdentity = DomainDrivenDesignExample.Domain.Aggregates.IIdentity;

namespace DomainDrivenDesignExample.Repositories;

public class EventStoreRepository : IEventStoreRepository
{
    private Dictionary<string, EventStream> _eventStore = new Dictionary<string, EventStream>();

    public EventStream Get(IIdentity identity)
    {
        return _eventStore[identity.ToString()];
    }

    public List<EventStream> List(string aggregateType)
    {
        return _eventStore
            .Where(o => o.Key.StartsWith(aggregateType))
            .Select(o => o.Value)
            .ToList();
    }

    public void Save(IAggregateRoot aggregateRoot)
    {
        var uncommittedEvents = aggregateRoot.GetUncommittedEvents();
        if (!uncommittedEvents.Any())
        {
            return;
        }

        var stream = _eventStore.GetValueOrDefault(aggregateRoot.Identity.ToString(), new EventStream());
        stream.Version = aggregateRoot.Version;
        stream.Events.AddRange(uncommittedEvents);
        _eventStore[aggregateRoot.Identity.ToString()] = stream;
    }
}
