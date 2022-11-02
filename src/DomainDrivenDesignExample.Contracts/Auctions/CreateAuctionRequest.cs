namespace DomainDrivenDesignExample.Contracts.Auctions;

public record CreateAuctionRequest
{
    public string Number { get; init; }
}
