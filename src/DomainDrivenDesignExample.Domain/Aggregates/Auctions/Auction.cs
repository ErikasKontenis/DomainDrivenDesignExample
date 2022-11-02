using DomainDrivenDesignExample.Domain.Commands.Auctions;
using DomainDrivenDesignExample.Domain.Events;
using DomainDrivenDesignExample.Domain.Events.Auctions;

namespace DomainDrivenDesignExample.Domain.Aggregates.Auctions;

public class Auction : AggregateRootBase<AuctionState>
{
    public Auction(IEnumerable<EventBase> events)
        : base(new AuctionState(events))
    { }

    public void Create(CreateAuctionCommand command)
    {
        var @event = new AuctionCreatedEvent
        {
            CreatedUtc = DateTime.UtcNow,
            EventDateUtc = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            Number = command.Number
        };

        Apply(@event);
    }

    public void Bid(BidAuctionCommand command)
    {
        if (command.Value <= State.Value)
        {
            throw new Exception("Value cannot be less than current value");
        }

        var @event = new AuctionBiddedEvent
        {
            Id = State.Id,
            EventDateUtc = DateTime.UtcNow,
            Value = command.Value
        };

        Apply(@event);
    }
}
