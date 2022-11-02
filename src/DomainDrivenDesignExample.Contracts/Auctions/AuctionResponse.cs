namespace DomainDrivenDesignExample.Contracts.Auctions;

public record AuctionResponse
{
    public Guid Id { get; init; }

    public string Number { get; init; }

    public DateTime CreatedUtc { get; init; }

    public decimal Value { get; init; }
}
