using DomainDrivenDesignExample.Domain.Events;
using DomainDrivenDesignExample.Domain.Events.Auctions;

namespace DomainDrivenDesignExample.Domain.Aggregates.Auctions;

public class AuctionState : AggregateStateBase
{
    public AuctionState(IEnumerable<EventBase> events)
        : base(events)
    { }

    public string Number { get; protected set; }

    public decimal Value { get; protected set; }

    public DateTime CreatedUtc { get; protected set; }

    public void When(AuctionCreatedEvent @event)
    {
        Id = @event.Id;
        CreatedUtc = @event.CreatedUtc;
        Number = @event.Number;
    }

    public void When(AuctionBiddedEvent @event)
    {
        Value = @event.Value;
    }
}
