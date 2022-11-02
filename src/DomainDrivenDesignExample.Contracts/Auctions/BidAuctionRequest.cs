namespace DomainDrivenDesignExample.Contracts.Auctions;

public record BidAuctionRequest
{
    public decimal Value { get; init; }
}
