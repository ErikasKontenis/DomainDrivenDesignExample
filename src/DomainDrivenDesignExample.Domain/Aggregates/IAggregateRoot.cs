using DomainDrivenDesignExample.Domain.Events;

namespace DomainDrivenDesignExample.Domain.Aggregates
{
    public interface IAggregateRoot
    {
        Identity Identity { get; }

        long Version { get; }

        void Apply(EventBase @event);

        IEnumerable<EventBase> GetUncommittedEvents();
    }
}
