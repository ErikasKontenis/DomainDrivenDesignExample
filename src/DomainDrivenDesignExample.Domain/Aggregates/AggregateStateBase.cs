using DomainDrivenDesignExample.Domain.Events;

namespace DomainDrivenDesignExample.Domain.Aggregates;

public abstract class AggregateStateBase : IAggregateState
{
    protected AggregateStateBase(IEnumerable<EventBase> events)
    {
        EventCount = events.Count();
        for (var i = 0; i < EventCount; i++)
        {
            Mutate(events.ElementAt(i));
        }
    }

    public int EventCount { get; private set; }

    public Guid Id { get; protected set; }

    public void Mutate(object @event)
    {
        ((dynamic)this).When((dynamic)@event);
    }
}
