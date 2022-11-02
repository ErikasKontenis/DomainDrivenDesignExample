namespace DomainDrivenDesignExample.Domain.Events.Auctions;

public class AuctionBiddedEvent : EventBase
{
    public decimal Value { get; set; }
}
