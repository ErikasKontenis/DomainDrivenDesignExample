namespace DomainDrivenDesignExample.Domain.Aggregates;

public interface IAggregateState
{
    int EventCount { get; }

    Guid Id { get; }

    void Mutate(object @event);
}
