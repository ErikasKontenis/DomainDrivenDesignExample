namespace DomainDrivenDesignExample.Domain.Events.Auctions;

public class AuctionCreatedEvent : EventBase
{
    public string Number { get; set; }

    public DateTime CreatedUtc { get; set; }
}
